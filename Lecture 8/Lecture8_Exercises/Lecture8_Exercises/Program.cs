using System;
using System.Linq;

namespace ProSE
{
    class FirstClass
    {
        public static void Main(string[] args)
        {
            string filePath = "pokedex.xml";

            var listOfPokemons = HelperFunctions.ExtractFromXML(filePath);

            var myPokedex = new Pokedex(listOfPokemons);

            var flyingTypes = from pokemon in myPokedex.Pokemons
                             where pokemon.Type.Contains("FLYING")
                             orderby pokemon.Species
                             select pokemon;

            //myPokedex.PrintPokemons();

            foreach (var flyingType in flyingTypes)
            {
                Console.WriteLine(flyingType.Species);
                DatabaseFramework.AddPokemon(flyingType);
            }

        }
    }

}