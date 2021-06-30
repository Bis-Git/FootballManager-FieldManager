using ProjectLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNETProjekt
{
    public partial class Settings : Form
    {
        private const string APP_SETTINGS = "appSettings.txt";
        private readonly string settingsFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"ProjectLib\Settings");


        public Settings()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            InitComboBox(cbChampionship, "Male", "Female");
            InitComboBox(cbLanguage, "English", "Croatian");
        }

        private void InitComboBox(ComboBox cb, params string[] item)
        {
            for (int i = 0; i < item.Length; i++)
            {
                cb.Items.Add(item[i]);
            }

            if (!File.Exists(Path.Combine(settingsFilePath, APP_SETTINGS)))
            {
                cb.SelectedIndex = 0;
            }
            else
            {
                string settings = Repository.GetPropertiesFromFile(Path.Combine(settingsFilePath, APP_SETTINGS));
                string[] settingsArray = settings.Split(';');
                string championship = settingsArray[0].Substring(settingsArray[0].IndexOf(':') + 1);
                string language = settingsArray[1].Substring(settingsArray[1].IndexOf(':') + 1);

                cbChampionship.SelectedItem = championship;
                if (language.Equals("en"))
                {
                    cbLanguage.SelectedItem = "English";
                }
                else
                {
                    cbLanguage.SelectedItem = "Croatian";
                }
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string championship = cbChampionship.SelectedItem.ToString();
            string language;


            if (cbLanguage.SelectedItem.ToString().Equals("English"))
            {
                language = "en";
            }
            else
            {
                language = "hr";
            }


            StringBuilder sb = new StringBuilder();
            sb.Append("Championship:");
            sb.Append(championship);
            sb.Append(Environment.NewLine);
            sb.Append("Language:");
            sb.Append(language);

            Repository.SaveToFile(sb.ToString(), Path.Combine(settingsFilePath, APP_SETTINGS));
        }
    }
}
