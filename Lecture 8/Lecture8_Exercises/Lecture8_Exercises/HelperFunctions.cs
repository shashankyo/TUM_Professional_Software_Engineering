using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProSE
{
    public class HelperFunctions
    {
        public static List<Pokemon> ExtractFromXML (string filePath)
        {

            var pokemonList = new List<Pokemon>();
            var pokemonXML = new XmlDocument();
            pokemonXML.Load(filePath);

            //TODO take all the lectures from xml and pushback --> timetable

            var pokemonNodes = pokemonXML.DocumentElement.ChildNodes;

            foreach (XmlNode pokemonNode in pokemonNodes)
            {
                var pokemon = HelperFunctions.GetPokemonInfo(pokemonNode); //wip

                pokemonList.Add(pokemon);
            }

            return pokemonList;
        }
        private static Pokemon GetPokemonInfo(XmlNode lectureNode)
        {
            string Species = " ", Type = " ";
            int Dex = 1;

            foreach (XmlNode node in lectureNode)
            {
                if (node.Name == "species")
                {
                    Species = node.InnerText;
                }
                else if (node.Name == "types")
                {
                    Type = node.InnerText;
                }
                else if (node.Name == "dex")
                {
                    Dex = Convert.ToInt32(node.InnerText);
                }
            }
            return new Pokemon(Species, Dex, Type);
        }
    }

}
