using ProjectLib;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private readonly string settingsFilePath = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"ProjectLib\Settings");
        public Settings()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitComboBox(cbChampionship, "Male", "Female");
            InitComboBox(cbLanguage, "English", "Croatian");
            InitComboBox(cbResolution, "1280 x 720", "1920 x 1080", "Fullscreen");
        }

        private void InitComboBox(ComboBox cb, params string[] item)
        {
            for (int i = 0; i < item.Length; i++)
            {
                cb.Items.Add(item[i]);
            }

            if (!File.Exists(Path.Combine(settingsFilePath, "appSettings.txt")))
            {
                cb.SelectedIndex = 0;
            }
            else
            {
                string[] appSettings = Repository.GetPropertiesFromFile(Path.Combine(settingsFilePath, "appSettings.txt")).Split(';');
                string championship = appSettings[0].Substring(appSettings[0].IndexOf(':') + 1);
                string language = appSettings[1].Substring(appSettings[1].IndexOf(':') + 1);
                string resolution;

                if (appSettings.Length == 3)
                {
                    resolution = appSettings[2].Substring(appSettings[2].IndexOf(':') + 1);
                }
                else
                {
                    resolution = "";
                }

                cbChampionship.SelectedItem = championship;
                if (language.Equals("en"))
                {
                    cbLanguage.SelectedItem = "English";
                }
                else
                {
                    cbLanguage.SelectedItem = "Croatian";
                }

                cbResolution.SelectedItem = resolution;
               
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            string championship = cbChampionship.SelectedItem.ToString();
            string language;
            string resolution = cbResolution.SelectedItem.ToString();


            if (cbLanguage.SelectedItem.ToString().Equals("English"))
            {
                language = "en";
            }
            else
            {
                language = "hr";
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("Championship:" + championship);
            sb.Append(Environment.NewLine);
            sb.Append("Language:" + language);
            sb.Append(Environment.NewLine);
            sb.Append("Resolution:" + resolution);

            Repository.SaveToFile(sb.ToString(), Path.Combine(settingsFilePath, "appSettings.txt"));
            Close();
        }
    }
}