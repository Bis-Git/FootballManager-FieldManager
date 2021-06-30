using Newtonsoft.Json;
using System.Drawing;
using System.Web.UI.WebControls;

namespace ProjectLib.Models
{
    public class Player
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "captain")]
        public bool Captain { get; set; }
        [JsonProperty(PropertyName = "shirt_number")]
        public int ShirtNumber { get; set; }
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }

        public int GoalCount { get; set; }
        public int YellowCardCount { get; set; }

        public Bitmap Image { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as Player;

            return this.Name.Equals(item.Name);
        }

        public override int GetHashCode() => (Name + Position).GetHashCode();

        public override string ToString() => $"{Name},{Captain},{ShirtNumber},{Position}";
    }
}
