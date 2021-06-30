using ProjectLib;
using ProjectLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsProjekt;

namespace OOPNETProjekt
{
    public partial class MainForm : Form
    {
        private const string USER_SETTINGS = "userSettings.txt";
        private const string APP_SETTINGS = "appSettings.txt";

        private readonly string settingsFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"ProjectLib\Settings");
        private readonly string playerPicutreFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Images\Player pictures\");
        private readonly string assetsFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Images\Assets");

        private Representation selectedRepresentation;
        private List<Match> matchData;
        private List<PlayerControl> players;
        private PlayerControl selectedPlayer = null;
        private FlowLayoutPanel DnDStarterContainer;
        private ApplicationSettings applicatonSettings;

        private string championshipURL;
        private string playerDataURL;
        private string language;

        public MainForm()
        {
            InitSettings();
            SetCulture(language);

            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            BackgroundImage = Image.FromFile(Path.Combine(assetsFilePath, "background2.jpg"));
            BackgroundImageLayout = ImageLayout.Stretch;

            InitForm();
        }


        private void SetCulture(string language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        }

        private void InitForm()
        {
            ShowRepresentations();
            ShowFavouritePlayers();
            ShowPlayers();
            ShowRankings();
        }
        private void InitSettings()
        {
            if (!File.Exists(Path.Combine(settingsFilePath, APP_SETTINGS)))
            {
                Settings settingsForm = new Settings();
                settingsForm.ShowDialog();

                if (settingsForm.DialogResult != DialogResult.OK)
                {
                    Dispose();
                }
            }

            GetSettings();

        }
        private void GetSettings()
        {
            string[] appSettings = Repository.GetPropertiesFromFile(APP_SETTINGS).Split(';');
            string[] userSettings = Repository.GetPropertiesFromFile(USER_SETTINGS).Split(';');

            string championship = appSettings[0].Substring(appSettings[0].IndexOf(':') + 1);
            SetUrls(championship);
            language = appSettings[1].Substring(appSettings[1].IndexOf(':') + 1);

            List<Player> favouritePlayers = new List<Player>();
            Representation representation = new Representation();


            if (File.Exists(Path.Combine(settingsFilePath, USER_SETTINGS)))
            {
                string favouriteRepresentation = userSettings[0].Substring(userSettings[0].IndexOf(':') + 1);
                string country = favouriteRepresentation.Substring(0, favouriteRepresentation.IndexOf(' '));
                string fifaCode = favouriteRepresentation.Substring(favouriteRepresentation.IndexOf('(') + 1, 3);
                representation = new Representation(country, fifaCode);

                string[] favouritePlayersString = (userSettings[1].Substring(userSettings[1].IndexOf(':') + 1)).Split('/')[0] == "" ?
                    null : (userSettings[1].Substring(userSettings[1].IndexOf(':') + 1)).Split('/');


                if (favouritePlayersString != null)
                {

                    for (int i = 0; i < favouritePlayersString.Length; i++)
                    {
                        if (!favouritePlayersString[i].Equals(""))
                        {
                            string[] data = favouritePlayersString[i].Split(',');
                            favouritePlayers.Add(new Player
                            {
                                Name = data[0],
                                Captain = data[1].Equals("true") ? true : false,
                                ShirtNumber = int.Parse(data[2]),
                                Position = data[3]

                            });
                        }
                    }
                }
            }

            applicatonSettings = new ApplicationSettings
            {
                Championship = championship,
                Language = language,
                Representation = representation,
                FavouritePlayers = favouritePlayers
            };
        }

        private void ShowPlayers()
        {
            selectedRepresentation = (Representation)cbRepresentations.SelectedItem;

            GetSettings();

            flpPlayersContainer.Controls.AddRange(players.ToArray());
            foreach (PlayerControl pc in flpFavouritePlayersContainer.Controls)
            {
                if (flpPlayersContainer.Controls.Contains(pc))
                {
                    int i = flpPlayersContainer.Controls.GetChildIndex(pc);
                    flpPlayersContainer.Controls.RemoveAt(i);
                }

            }
        }
        private List<PlayerControl> GetPlayerControls()
        {
            string representationDataUrl = GetUrl();
            string country = cbRepresentations.SelectedItem.ToString().
                Substring(0, cbRepresentations.SelectedItem.ToString().IndexOf(' '));

            matchData = Repository.GetMatchData(representationDataUrl);

            HashSet<Player> team = new HashSet<Player>();
            GetPlayers(country, team);

            List<PlayerControl> playerControls = new List<PlayerControl>();
            foreach (var p in team)
            {
                PlayerControl control = new PlayerControl();
                control.tbName.Text = p.Name;
                control.tbShirtNumber.Text = p.ShirtNumber.ToString();
                control.tbPosition.Text = p.Position;
                control.tbCaptian.Text = p.Captain ? "Captain" : "Not captain";
                control.ContextMenuStrip = cmsPlayer;
                SetPicture(control, p.Name, ".jpeg");

                control.MouseDown += PlayerCotrol_MouseDown;

                playerControls.Add(control);
            }

            return playerControls;
        }
        private void GetPlayers(string country, HashSet<Player> team)
        {
            foreach (var data in matchData)
            {
                if (data.HomeTeam.Country.Equals(country))
                {
                    var startingEleven = data.HomeTeamStatistics.StartingEleven;
                    var substitutes = data.HomeTeamStatistics.Substitutes;

                    startingEleven.ForEach(x => team.Add(x));
                    substitutes.ForEach(x => team.Add(x));
                }
                else
                {
                    var startingEleven = data.AwayTeamStatistics.StartingEleven;
                    var substitutes = data.AwayTeamStatistics.Substitutes;

                    startingEleven.ForEach(x => team.Add(x));
                    substitutes.ForEach(x => team.Add(x));
                }

            }
        }
        private void ShowFavouritePlayers()
        {

            try
            {
                if (applicatonSettings.FavouritePlayers != null)
                {
                    List<Player> favouritePlayers = applicatonSettings.FavouritePlayers;
                    foreach (Player player in favouritePlayers)
                    {
                        PlayerControl control = new PlayerControl();
                        control.tbName.Text = player.Name;
                        control.tbCaptian.Text = player.Captain ? "Captain" : "Not captain";
                        control.tbShirtNumber.Text = player.ShirtNumber.ToString();
                        control.tbPosition.Text = player.Position;

                        control.MouseDown += PlayerCotrol_MouseDown;
                        control.ContextMenuStrip = cmsFavouritePlayer;
                        control.pbFavourite.Image = new Bitmap(Path.Combine(assetsFilePath, "favouriteIcon.jpeg"));
                        SetPicture(control, player.Name, ".jpeg");

                        flpFavouritePlayersContainer.Controls.Add(control);
                    }

                }

            }
            catch (Exception)
            {
                return;
            }
        }

        private void SetPicture(PlayerControl control, string title, string ext)
        {

            if (File.Exists(Path.Combine(playerPicutreFilePath, title + ext)))
            {
                control.pbImage.Image = new Bitmap(Path.Combine(playerPicutreFilePath, title + ext));
            }
            else
            {
                control.pbImage.Image = new Bitmap(Path.Combine(assetsFilePath, "noPicture.jpeg"));
            }
        }

        private void ShowRepresentations()
        {
            List<Representation> representations = Repository.GetRepresentationsData(championshipURL);

            cbRepresentations.DataSource = representations;
            foreach (Representation c in cbRepresentations.Items)
            {
                if (c.ToString() == applicatonSettings.Representation.ToString())
                {
                    cbRepresentations.SelectedItem = c;
                    break;
                }
            }
        }
        private void ShowRankings()
        {
            dgvGoal.Rows.Clear();
            dgvYellowCard.Rows.Clear();
            dgvMatch.Rows.Clear();
            string country = cbRepresentations.SelectedItem.ToString().
                            Substring(0, cbRepresentations.SelectedItem.ToString().IndexOf(' '));

            HashSet<Player> players = new HashSet<Player>();

            GetPlayers(country, players);
            foreach (Player player in players)
            {
                if (File.Exists(Path.Combine(playerPicutreFilePath, player.Name + ".jpeg")))
                {
                    player.Image = new Bitmap(Path.Combine(playerPicutreFilePath, player.Name + ".jpeg"));
                }
                else
                {
                    player.Image = new Bitmap(Path.Combine(assetsFilePath, "noPicture.jpeg"));
                }
            }

            foreach (var data in matchData)
            {
                if (data.HomeTeam.Country.Equals(country))
                {
                    FillEventsData(players, data.HomeTeamEvents);
                }
                else
                {
                    FillEventsData(players, data.AwayTeamEvents);
                }
            }
            players.ToList().ForEach(x => dgvGoal.Rows.Add(
                x.Image, 
                x.Name.Substring(0, x.Name.IndexOf(' ')), 
                x.Name.Substring(x.Name.IndexOf(' ') + 1), 
                x.GoalCount));
            dgvGoal.Sort(clmNumGoals, ListSortDirection.Descending);

            players.ToList().ForEach(x => dgvYellowCard.Rows.Add(
                x.Image, 
                x.Name.Substring(0, x.Name.IndexOf(' ')), 
                x.Name.Substring(x.Name.IndexOf(' ') + 1), 
                x.YellowCardCount));
            dgvYellowCard.Sort(clmYellowCards, ListSortDirection.Descending);

            matchData.ForEach(x => dgvMatch.Rows.Add(x.Location, x.Attendance, x.HomeTeam.Country, x.AwayTeam.Country));
        }

        private void SetUrls(string championship)
        {
            championshipURL = championship.Equals("Male") ? ConfigurationManager.AppSettings.Get("maleRepURL") :
                        ConfigurationManager.AppSettings.Get("femaleRepURL");
            playerDataURL = championship.Equals("Male") ? ConfigurationManager.AppSettings.Get("maleRepPlayerDataURL") :
                        ConfigurationManager.AppSettings.Get("femaleRepPlayerDataURL");
        }
        private string GetUrl()
        {
            string fifaCode = selectedRepresentation.FifaCode;
            return playerDataURL + fifaCode;
        }

        private static void FillEventsData(HashSet<Player> players, List<TeamEvents> data)
        {
            data.ForEach(x =>
            {
                if (x.TypeOfEvent.Equals("goal"))
                {
                    Player player = players.First(y => y.Name.Equals(x.Player));
                    player.GoalCount++;
                }
                else if (x.TypeOfEvent.Equals("yellow-card"))
                {
                    Player player = players.First(y => y.Name.Equals(x.Player));
                    player.YellowCardCount++;
                }
            });
        }

        private void cbRepresentations_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpPlayersContainer.Controls.Clear();
            flpFavouritePlayersContainer.Controls.Clear();

            selectedRepresentation = (Representation)cbRepresentations.SelectedItem;

            if (players != null)
            {
                players.Clear();
            }
            players = GetPlayerControls();
            flpPlayersContainer.Controls.AddRange(players.ToArray());
            ShowRankings();
        }

        private void tsmiAddPicture_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            ContextMenuStrip owner = item.Owner as ContextMenuStrip;
            PlayerControl control = owner.SourceControl as PlayerControl;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; " +
                "| All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = dialog.FileName;

                    control.pbImage.Image = new Bitmap(path);
                    if (!Directory.Exists(playerPicutreFilePath))
                    {
                        Directory.CreateDirectory(playerPicutreFilePath);
                    }
                    control.pbImage.Image.Save(playerPicutreFilePath + control.tbName.Text + ".jpeg", ImageFormat.Jpeg);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to set/save image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();

            if (settings.DialogResult == DialogResult.OK)
            {
                GetSettings();
                SetUrls(applicatonSettings.Championship);
                UpdateCulture();


                ShowRepresentations();
                ShowRankings();
            }

        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiAddFavourite_Click(object sender, EventArgs e)
        {

            if (flpFavouritePlayersContainer.Controls.Count < 3)
            {
                GetPlayerControlFromCMS(sender, cmsFavouritePlayer);
                flpFavouritePlayersContainer.Controls.Add(selectedPlayer);
                flpPlayersContainer.Controls.Remove(selectedPlayer);
            }
        }

        private void tsmiRemoveFavourite_Click(object sender, EventArgs e)
        {
            GetPlayerControlFromCMS(sender, cmsPlayer);

            flpPlayersContainer.Controls.Add(selectedPlayer);
            flpFavouritePlayersContainer.Controls.Remove(selectedPlayer);
        }

        private void GetPlayerControlFromCMS(object sender, ContextMenuStrip cms)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            ContextMenuStrip menu = menuItem.Owner as ContextMenuStrip;
            selectedPlayer = menu.SourceControl as PlayerControl;

            selectedPlayer.ContextMenuStrip = cms;
            if (cms == cmsFavouritePlayer)
            {
                lblInfo.Text = "Player added to favourites";
            }
            else
            {
                lblInfo.Text = "Player removed from favourites";
            }
        }

        private void PlayerCotrol_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PlayerControl control = sender as PlayerControl;
                DnDStarterContainer = (FlowLayoutPanel)control.Parent;

                control.DoDragDrop(control, DragDropEffects.Move);
            }
        }

        private void PlayersContainer_DragEnter(object sender, DragEventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;
            if (flp == DnDStarterContainer) return;

            flp.BackColor = Color.FromArgb(192, 255, 255);

            e.Effect = DragDropEffects.Move;
            lblInfo.Text = "Drop allowed";
        }

        private void PlayersContainer_DragLeave(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;

            flp.BackColor = SystemColors.Control;
            lblInfo.Text = "Drop not allowed";
        }

        private void PlayersContainer_DragDrop(object sender, DragEventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;
            var data = (PlayerControl)e.Data.GetData(typeof(PlayerControl));

            if (flp == flpFavouritePlayersContainer)
            {
                if (flpFavouritePlayersContainer.Controls.Count < 3)
                {
                    flp.Controls.Add(data);
                    lblInfo.Text = "Player added to favourites";
                    data.ContextMenuStrip = cmsFavouritePlayer;
                    data.pbFavourite.Image = new Bitmap(Path.Combine(assetsFilePath, "favouriteIcon.jpeg"));
                }
                else
                {
                    lblInfo.Text = "Too many favourite players, maximum allowed number is 3";
                    flp.BackColor = SystemColors.Control;
                    return;
                }
            }
            else
            {
                flp.Controls.Add(data);
                data.ContextMenuStrip = cmsPlayer;
                data.pbFavourite.Image = null;
                lblInfo.Text = "Player removed from favourites";
            }

            flp.BackColor = SystemColors.Control;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var window = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);

            if (window == DialogResult.Yes)
            {
                try
                {
                    SaveFavourites();
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not save preferences, exiting application",
                        "Unrecoverable error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }

            e.Cancel = (window == DialogResult.No);
        }

        private void SaveFavourites()
        {
            string selectedRepresentation = cbRepresentations.SelectedItem.ToString();
            List<Player> favouritePlayers = new List<Player>();

            foreach (PlayerControl p in flpFavouritePlayersContainer.Controls)
            {
                favouritePlayers.Add(new Player
                {
                    Name = p.tbName.Text,
                    Captain = p.tbCaptian.Equals("Captain") ? true : false,
                    Position = p.tbPosition.Text,
                    ShirtNumber = int.Parse(p.tbShirtNumber.Text)
                });
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Favourite representation:");
            sb.Append(selectedRepresentation);
            sb.Append(Environment.NewLine);
            sb.Append("Favourite players:");
            foreach (Player player in favouritePlayers)
            {
                sb.Append(player.ToString());
                sb.Append("/");
            }

            Repository.SaveToFile(sb.ToString(), Path.Combine(settingsFilePath, USER_SETTINGS));
        }

        private void UpdateCulture()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            if (currentCulture.Equals("hr"))
            {
                SetCulture("en");
            }
            else
            {
                SetCulture("hr");
            }
            Controls.Clear();
            this.FormClosing -= MainForm_FormClosing;

            InitializeComponent();

        }

    }
}
