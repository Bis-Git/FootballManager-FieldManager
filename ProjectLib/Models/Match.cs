using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Models
{
    public class Match
    {
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
        [JsonProperty(PropertyName = "attendance")]
        public int Attendance { get; set; }
        [JsonProperty(PropertyName = "winner")]
        public string Winner { get; set; }
        [JsonProperty(PropertyName = "home_team")]
        public Team HomeTeam{ get; set; }
        [JsonProperty(PropertyName = "away_team")]
        public Team AwayTeam { get; set; }
        [JsonProperty(PropertyName = "home_team_events")]
        public List<TeamEvents> HomeTeamEvents { get; set; }
        [JsonProperty(PropertyName = "away_team_events")]
        public List<TeamEvents> AwayTeamEvents { get; set; }
        [JsonProperty(PropertyName = "home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }
        [JsonProperty(PropertyName = "away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }

    }
}
