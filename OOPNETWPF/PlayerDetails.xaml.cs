using ProjectLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OOPNETWPF
{
    /// <summary>
    /// Interaction logic for PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : Window
    {
        private Player player;
        private readonly string playerPicutreFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Images\Player pictures\");
        private readonly string assetsFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Images\Assets");


        public PlayerDetails(PlayerControl control)
        {
            InitializeComponent();
            player = control.player;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            ShowDetails();
        }


        private void ShowDetails()
        {
            playerName.Text = player.Name;
            shirtNumber.Text = player.ShirtNumber.ToString();
            position.Text = player.Position;
            isCaptian.Text = player.Captain ? "Captian" : "Not captian";
            goalNum.Text = player.GoalCount.ToString();
            yellowCardNum.Text = player.YellowCardCount.ToString();
            playerImage.Source = SetImage();
        }

        private ImageSource SetImage()
        {
            string path = Path.Combine(playerPicutreFilePath, player.Name + ".jpeg");
            string defaultPath = Path.Combine(assetsFilePath, "noPicture.jpeg");

            if (File.Exists(path))
            {
                return new BitmapImage(new Uri(path));
            }
            else
            {
                return new BitmapImage(new Uri(defaultPath));
            }
        }
    }
}
