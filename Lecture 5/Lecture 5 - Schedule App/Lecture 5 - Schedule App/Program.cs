using System;
using System.Xml;

namespace ProSE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Koray Program");

            // File Path
            string filePath = "D:\\WIP\\00_Akademic_TUM_ITBE\\1. Semester\\Professional Software Engineering\\Lecture 5\\Lecture 5 - Schedule App\\Lecture 5 - Schedule App\\Koray_Inal_Terminkalender_Woche.xml";
            
            XmlTextReader reader = new XmlTextReader(filePath);
            
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;

                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }

        }
    }
}