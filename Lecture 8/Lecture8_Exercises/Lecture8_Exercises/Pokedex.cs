using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class Pokedex
    {
        public List<Pokemon> Pokemons { get; set; }

        public Pokedex(List<Pokemon> pokemons)
        {
            Pokemons = pokemons;
        }

        public void PrintPokemons()
        {
            foreach (var pokemon in Pokemons)
            {
                Console.WriteLine("----");
                Console.Write("Species: ");
                Console.WriteLine(pokemon.Species);
                Console.Write("Type: ");
                Console.WriteLine(pokemon.Type);
                Console.Write("Dex: ");
                Console.WriteLine(pokemon.Dex);
                Console.WriteLine("----");

            }
        }
    }
}
