using ProSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class DatabaseFramework
    {
        public static void AddPokemon(Pokemon pokemon)
        {
            using (var context = new PokedexContext())
            {
                context.Pokemons.Add(pokemon);
                context.SaveChanges();
            }
        }
    }
}
