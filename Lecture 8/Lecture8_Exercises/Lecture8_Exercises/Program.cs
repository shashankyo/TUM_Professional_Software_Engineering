using System;
using System.Linq;

namespace ProSE
{
    class FirstClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test ...");

            string filePath = "pokedex.xml";

            var listOfPokemons = HelperFunctions.ExtractFromXML(filePath);

            foreach (var pokemon in listOfPokemons)
            {
                Console.WriteLine("----");
                Console.WriteLine("Species:");
                Console.WriteLine(pokemon.Species);
                Console.WriteLine("Type:");
                Console.WriteLine(pokemon.Type);
                Console.WriteLine("----");
            }

        }
    }

}