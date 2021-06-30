using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Models
{
    public class ApplicationSettings
    {
        public string Championship { get; set; }
        public string Language { get; set; }
        public Representation Representation { get; set; }
        public List<Player> FavouritePlayers { get; set; }
        public string Resolution { get; set; }

    }
}
