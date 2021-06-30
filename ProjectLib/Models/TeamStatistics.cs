using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProjectLib.Models
{
    public class TeamStatistics
    {
        [JsonProperty(PropertyName = "starting_eleven")]
        public List<Player> StartingEleven { get; set; }
        [JsonProperty(PropertyName = "substitutes")]
        public List<Player> Substitutes { get; set; }
    }
}
