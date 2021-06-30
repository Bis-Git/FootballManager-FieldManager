using ProjectLib;
using ProjectLib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace OOPNETWPF
{
    /// <summary>
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {
        private List<Match> matchData;
        private Representation representation;

        private int gameNum;
        private int wins;
        private int losses;
        private int scoredGoals = 0;
        private int receviedGoals = 0;


        public TeamDetails(Representation representation)
        {
            this.representation = representation;
            matchData = Repository.GetMatchData(GetUrl());

            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            GetUrl();
            InitStatistics();
            ShowDetails();
        }

        private string GetUrl()
        {
            string[] appSettings = Repository.GetPropertiesFromFile("appSettings.txt").Split(';');

            string championship = appSettings[0].Substring(appSettings[0].IndexOf(':') + 1);

            string playerDataURL = championship.Equals("Male") ? ConfigurationManager.AppSettings["maleRepPlayerDataURL"].ToString() :
                        ConfigurationManager.AppSettings["femaleRepPlayerDataURL"].ToString();

            string fifaCode = representation.FifaCode;
            return playerDataURL + fifaCode;
        }

        private void InitStatistics()
        {
            List<TeamEvents> events = new List<TeamEvents>();
            foreach (var data in matchData)
            {
                gameNum++;
                if (representation.Country.Equals(data.Winner))
                {
                    wins++;
                }
                else
                {
                    losses++;
                }

                scoredGoals += representation.Country.Equals(data.HomeTeam.Country) ? data.HomeTeam.Goals : data.AwayTeam.Goals;
                receviedGoals += !representation.Country.Equals(data.HomeTeam.Country) ? data.HomeTeam.Goals : data.AwayTeam.Goals;

            }

        }

        private void ShowDetails()
        {
            int diff = scoredGoals >= receviedGoals ? scoredGoals - receviedGoals : receviedGoals - scoredGoals;

            teamName.Text = representation.Country;
            fifaCode.Text = representation.FifaCode;
            gameStats.Text = $"{gameNum}/{wins}/{losses}";
            goalStats.Text = $"{scoredGoals}/{receviedGoals}/{diff}";
        }
    }
}
