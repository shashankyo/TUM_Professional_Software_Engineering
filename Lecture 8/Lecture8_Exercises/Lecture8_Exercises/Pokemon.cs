using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class Pokemon
    {
        public string Species { get; set; }
        public int Dex { get; set; }
        public string Type { get; set; }
        
        public Pokemon(string Species, int Dex, string Type)
        {
            this.Species = Species;
            this.Dex = Dex;
            this.Type = Type;

        }

    }
}
