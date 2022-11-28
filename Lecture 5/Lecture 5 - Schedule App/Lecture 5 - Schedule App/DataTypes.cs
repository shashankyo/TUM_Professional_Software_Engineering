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
        public string startTime; 
        public string endTime;
        public string lectureName;
        public Days lectureDay; 
        
        private Lecture(string startTime, string endTime, string lectureName, Days lectureDay)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.lectureName = lectureName;
            this.lectureDay = lectureDay;
        }
        public static Lecture[] GetLectures(string filePath)
        {
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
            Lecture[] lectures = new Lecture();
            return lectures;
        }
        public string GetRows()
        {
            switch();
        }
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
