using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Models
{
    public class Representation
    {

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "fifa_code")]
        public string FifaCode { get; set; }

        public Representation()
        {
        }

        public Representation(string country, string fifaCode)
        {
            Country = country;
            FifaCode = fifaCode;
        }


        public override string ToString()
        {
            return $"{Country} ({FifaCode})";
        }
    }
}
