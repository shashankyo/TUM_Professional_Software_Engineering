using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProSE
{
    public enum Days
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
    }
    public class Lecture
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string lectureName { get; set; }
        public Days lectureDay {get; set; }
        
        private Lecture(string startTime, string endTime, string lectureName, Days lectureDay)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.lectureName = lectureName;
            this.lectureDay = lectureDay;
        }
        public static Lecture GetLectures(string filePath)
        {
            XmlTextReader reader = new XmlTextReader(filePath);
            
            while (reader.Read())
            {

                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write(reader.Name);
                        Console.Write(reader.GetType());
                        Console.WriteLine(">");
                        break;

                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                
                XmlNode 
                
                }

                
            }
            Lecture lectures = new Lecture("x","x0","x",Days.Monday);
            return lectures;
        }
        //public string GetRows()
        //{
        //    switch();
        //}
    }
        public class Timetable
        {
            public Lecture timetableLecture;
            public string owner;

            public Timetable(Lecture timetableLecture, string owner)
            {
                this.timetableLecture = timetableLecture;
                this.owner = owner;
            }
        }


}
