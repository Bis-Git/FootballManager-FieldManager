using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Models
{
    public class TeamEvents
    {
        [JsonProperty(PropertyName = "type_of_event")]
        public string TypeOfEvent { get; set; }
        [JsonProperty(PropertyName = "player")]
        public string Player { get; set; }
    }
}
