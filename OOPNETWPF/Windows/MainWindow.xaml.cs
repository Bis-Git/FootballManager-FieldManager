using ProjectLib;
using ProjectLib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace OOPNETWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string APP_SETTINGS = "appSettings.txt";
        private const string USER_SETTINGS = "userSettings.txt";

        private readonly string settingsFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"ProjectLib\Settings");
        private readonly string playerPicutreFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Images\Player pictures\");
        private readonly string assetsFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Images\Assets");

        private string championshipURL;
        private string playerDataURL;

        private ApplicationSettings applicationSettings;
        private List<Match> matchData;
        private Representation selectedRepresentation;

        public MainWindow()
        {
            InitSettings();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(applicationSettings.Language);

            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitRepresentations();
            this.Closing += MainWindow_Closing;
            this.SizeChanged += MainWindow_SizeChanged;
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RepositionControls(HomeGoalie);
            RepositionControls(AwayGoalie);
            RepositionControls(HomeDefender);
            RepositionControls(AwayDefender);
            RepositionControls(HomeMidfield);
            RepositionControls(AwayMidfield);
            RepositionControls(HomeForward);
            RepositionControls(AwayForward);
        }

        private void RepositionControls(StackPanel panel)
        {
            foreach (PlayerControl p in panel.Children)
            {
                p.Margin = new Thickness(0, ActualHeight / 25, 0, ActualHeight / 25);
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var window = new ClosingWindow();
            window.ShowDialog();

            if (!window.closeApp)
            {
                e.Cancel = true;
            }
        }



        private void InitSettings()
        {
            if (!File.Exists(settingsFilePath) && !ResolutionSettingExists())
            {
                new Settings().ShowDialog();
            }

            GetSettings();
            SetResolution();

        }

        private void SetResolution()
        {
            string resolution = applicationSettings.Resolution;
            switch (resolution)
            {
                case "Fullscreen":
                    WindowState = WindowState.Maximized;
                    break;
                case "1280 x 720":
                    if (WindowState == WindowState.Maximized)
                    {
                        WindowState = WindowState.Normal;
                    }
                    Width = 1280;
                    Height = 720;
                    break;
                case "1920 x 1080":
                    if (WindowState == WindowState.Maximized)
                    {
                        WindowState = WindowState.Normal;
                    }
                    Width = 1920;
                    Height = 1080;
                    break;
            }
        }

        private bool ResolutionSettingExists()
        {
            List<string> appSettings = Repository.GetPropertiesFromFile(APP_SETTINGS).Split(';').ToList();
            if (appSettings.Count == 3)
            {
                return true;
            }
            return false;
        }

        private void GetSettings()
        {
            string[] appSettings = Repository.GetPropertiesFromFile(APP_SETTINGS).Split(';');
            string[] userSettings = Repository.GetPropertiesFromFile(USER_SETTINGS).Split(';');

            string championship = appSettings[0].Substring(appSettings[0].IndexOf(':') + 1);
            SetUrls(championship);

            string language;

            if (appSettings[1].Substring(appSettings[1].IndexOf(':') + 1).Equals("en"))
            {
                language = "en-EN";
            }
            else
            {
                language = "hr-HR";
            }
            
            string resolution = appSettings[2].Substring(appSettings[2].IndexOf(':') + 1);

            if (userSettings.Length != 1)
            {
                Representation representation;


                string favouriteRepresentation = userSettings[0].Substring(userSettings[0].IndexOf(':') + 1);
                string country = favouriteRepresentation.Substring(0, favouriteRepresentation.IndexOf(' '));
                string fifaCode = favouriteRepresentation.Substring(favouriteRepresentation.IndexOf('(') + 1, 3);
                representation = new Representation(country, fifaCode);


                applicationSettings = new ApplicationSettings
                {
                    Championship = championship,
                    Language = language,
                    Resolution = resolution,
                    Representation = representation
                };
            }
            else
            {
                applicationSettings = new ApplicationSettings
                {
                    Championship = championship,
                    Language = language,
                    Resolution = resolution
                };
            }
        }

        private void InitRepresentations()
        {
            List<Representation> representations = Repository.GetRepresentationsData(championshipURL);

            cbHomeRepresentation.ItemsSource = representations;

            if (applicationSettings.Representation != null)
            {
                foreach (Representation c in cbHomeRepresentation.Items)
                {
                    if (c.ToString() == applicationSettings.Representation.ToString())
                    {
                        cbHomeRepresentation.SelectedItem = c;
                        break;
                    }
                }
            }
        }

        private void SetUrls(string championship)
        {
            championshipURL = championship.Equals("Male") ? ConfigurationManager.AppSettings["maleRepURL"].ToString() :
                        ConfigurationManager.AppSettings["femaleRepURL"].ToString();
            playerDataURL = championship.Equals("Male") ? ConfigurationManager.AppSettings["maleRepPlayerDataURL"].ToString() :
                        ConfigurationManager.AppSettings["femaleRepPlayerDataURL"].ToString();
        }

        private void cbHomeRepresentation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            selectedRepresentation = (Representation)cbHomeRepresentation.SelectedItem;
            string representationDataUrl = GetUrl();
            matchData = Repository.GetMatchData(representationDataUrl);
            List<Representation> guestRepresentations = new List<Representation>();

            btnShowHomeTeamDetails.Visibility = Visibility.Visible;

            foreach (var match in matchData)
            {
                Representation rep;
                if (selectedRepresentation.Country.Equals(match.HomeTeam.Country))
                {
                    rep = new Representation(match.AwayTeam.Country, match.AwayTeam.Code);

                }
                else
                {
                    rep = new Representation(match.HomeTeam.Country, match.HomeTeam.Code);
                }

                guestRepresentations.Add(rep);
            }

            cbAwayRepresentation.ItemsSource = guestRepresentations;
            ClearField();

        }

        private void ClearField()
        {
            HomeGoalie.Children.Clear();
            AwayGoalie.Children.Clear();
            HomeDefender.Children.Clear();
            AwayDefender.Children.Clear();
            HomeMidfield.Children.Clear();
            AwayMidfield.Children.Clear();
            HomeForward.Children.Clear();
            AwayForward.Children.Clear();
        }

        private BitmapImage ConvertBitmapToBitmapImage(Bitmap image)
        {
            if (image != null)
            {
                BitmapSource bs = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                return (BitmapImage)bs;
            }
            return null;
        }

        private string GetUrl()
        {
            string fifaCode = selectedRepresentation.FifaCode;
            return playerDataURL + fifaCode;
        }

        private void btnSettigs_Click(object sender, RoutedEventArgs e)
        {
            new Settings().ShowDialog();
            GetSettings();
            SetResolution();
        }

        private void cbAwayRepresentation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbAwayRepresentation.SelectedItem == null)
            {
                btnShowAwayTeamDetails.Visibility = Visibility.Hidden;
            }
            else
            {
                btnShowAwayTeamDetails.Visibility = Visibility.Visible;
            }

            ClearField();
            string homeCountry = cbHomeRepresentation.SelectedItem.ToString().
                Substring(0, cbHomeRepresentation.SelectedItem.ToString().IndexOf('(') - 1);

            if (cbAwayRepresentation.SelectedItem != null)
            {
                string awayCountry = cbAwayRepresentation.SelectedItem.ToString().
                Substring(0, cbAwayRepresentation.SelectedItem.ToString().IndexOf('(') - 1);


                ShowPlayers(homeCountry, awayCountry);

            }
        }

        private void ShowPlayers(string homeCountry, string awayCountry)
        {
            List<Player> startingEleven = GetStartingEleven(homeCountry, awayCountry);
            List<PlayerControl> DefenderList = new List<PlayerControl>();
            List<PlayerControl> MidfieldList = new List<PlayerControl>();
            List<PlayerControl> ForwardList = new List<PlayerControl>();
            GetPlayerControls(startingEleven, HomeGoalie, DefenderList, MidfieldList, ForwardList);

            FillPlayerField(HomeDefender, DefenderList);
            FillPlayerField(HomeMidfield, MidfieldList);
            FillPlayerField(HomeForward, ForwardList);

            HomeTeamEleven.Visibility = Visibility.Visible;

            DefenderList.Clear();
            MidfieldList.Clear();
            ForwardList.Clear();

            startingEleven = GetStartingEleven(awayCountry, homeCountry);
            GetPlayerControls(startingEleven, AwayGoalie, DefenderList, MidfieldList, ForwardList);
            FillPlayerField(AwayDefender, DefenderList);
            FillPlayerField(AwayMidfield, MidfieldList);
            FillPlayerField(AwayForward, ForwardList);

        }

        private void GetPlayerControls(List<Player> startingEleven, StackPanel Goalie, List<PlayerControl> DefenderList, List<PlayerControl> MidfieldList, List<PlayerControl> ForwardList)
        {
            foreach (var player in startingEleven)
            {
                PlayerControl control = new PlayerControl();
                control.player = player;
                control.playerName.Text = player.Name;
                var image = ConvertBitmapToBitmapImage(player.Image);
                control.playerImage.Source = GetPicture(player.Name);
                control.shirtNumber.Text = player.ShirtNumber.ToString();
                control.Background = System.Windows.Media.Brushes.White;
                control.MouseEnter += Control_MouseEnter;
                control.MouseLeave += Control_MouseLeave;
                control.MouseDown += Control_MouseDown;

                switch (player.Position)
                {
                    case "Goalie":
                        Goalie.Children.Add(control);
                        break;
                    case "Defender":
                        DefenderList.Add(control);
                        break;
                    case "Midfield":
                        MidfieldList.Add(control);
                        break;
                    case "Forward":
                        ForwardList.Add(control);
                        break;
                    default:
                        break;
                }

            }
        }

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayerControl control = sender as PlayerControl;
            PlayerDetails details = new PlayerDetails(control);
            details.ShowDialog();
        }

        private void Control_MouseLeave(object sender, MouseEventArgs e)
        {
            PlayerControl control = sender as PlayerControl;
            control.FontWeight = FontWeights.Normal;
            control.highlight.Visibility = Visibility.Hidden;
        }

        private void Control_MouseEnter(object sender, MouseEventArgs e)
        {
            PlayerControl control = sender as PlayerControl;
            control.FontWeight = FontWeights.Bold;
            control.highlight.Visibility = Visibility.Visible;
        }

        private ImageSource GetPicture(string name)
        {
            string path = Path.Combine(playerPicutreFilePath, name + ".jpeg");

            if (File.Exists(Path.Combine(path)))
            {
                return new BitmapImage(new Uri(path));
            }
            else
            {
                return new BitmapImage(new Uri(Path.Combine(assetsFilePath, "noPicture.jpeg")));
            }
        }

        private List<Player> GetStartingEleven(string homeCountry, string awayCountry)
        {
            List<Player> startingEleven = new List<Player>();
            List<TeamEvents> homeEvents = new List<TeamEvents>();
            List<TeamEvents> awayEvents = new List<TeamEvents>();
            foreach (var data in matchData)
            {
                if (data.HomeTeam.Country.Equals(homeCountry) && data.AwayTeam.Country.Equals(awayCountry))
                {
                    data.HomeTeamStatistics.StartingEleven.ForEach(x => startingEleven.Add(x));
                    homeEvents.AddRange(data.HomeTeamEvents);
                }
                else if (data.HomeTeam.Country.Equals(awayCountry) && data.AwayTeam.Country.Equals(homeCountry))
                {
                    data.AwayTeamStatistics.StartingEleven.ForEach(x => startingEleven.Add(x));
                    awayEvents.AddRange(data.AwayTeamEvents);
                }
            }


            foreach (var se in startingEleven)
            {
                foreach (var he in homeEvents)
                {
                    FillEvents(se, he);
                }
                foreach (var ae in awayEvents)
                {
                    FillEvents(se, ae);
                }
            }


            return startingEleven;
        }

        private static void FillEvents(Player se, TeamEvents he)
        {
            if (se.Name.Equals(he.Player) && he.TypeOfEvent.Equals("goal"))
            {
                se.GoalCount++;
            }
            else if (se.Name.Equals(he.Player) && he.TypeOfEvent.Equals("yellow-card"))
            {
                se.YellowCardCount++;
            }
        }

        private void FillPlayerField(StackPanel grid, List<PlayerControl> list)
        {

            for (int i = 0; i < list.Count; i++)
            {
                grid.Children.Add(list[i]);
                list[i].Margin = new Thickness(0, ActualHeight / 25, 0, ActualHeight / 25);
            }
        }

        private void btnShowHomeTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            Representation representation = (Representation)cbHomeRepresentation.SelectedItem;

            new TeamDetails(representation).ShowDialog();
        }

        private void btnShowAwayTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            Representation representation = (Representation)cbAwayRepresentation.SelectedItem;

            new TeamDetails(representation).ShowDialog();
        }
    }
}
