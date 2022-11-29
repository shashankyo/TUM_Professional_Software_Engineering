using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ProSE
{
    public enum Days
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }
    public class Lecture
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string lectureName { get; set; }
        public Days lectureDay { get; set; }


        private Lecture(string startTime, string endTime, string lectureName, Days lectureDay)
        {
            this.lectureName = lectureName;
            this.lectureDay = lectureDay;

            bool isValidStart = DateTime.TryParse(startTime, out _);
            bool isValidEnd = DateTime.TryParse(endTime, out _);

            if (isValidStart && isValidEnd)
            {
                this.startTime = startTime;
                this.endTime   = endTime;
            }
            else
            {
                Console.WriteLine("Invalid Time. Setting time from 12:00 to 1:00 am");

                this.startTime = "12:00 AM";
                this.endTime = "1:00 AM";
            }

        }
        public static Lecture GetLectures(XmlNode lecture)
        {
            string lectureName = " ", startTime = " ", endTime = " ";
            Days day = Days.Monday;
            foreach (XmlNode node in lecture)
            {
                if (node.Name == "TITEL")
                {
                    lectureName = node.InnerText;
                }
                else if (node.Name == "DATUM")
                {
                    var deCultureInfo = new CultureInfo("de-DE");
                    DateTime dateValue = DateTime.ParseExact(node.InnerText, "dd.MM.yyyy", deCultureInfo);

                    bool isValidDay = Enum.TryParse(dateValue.ToString("dddd"), out day);
                }
                else if (node.Name == "VON")
                {
                    startTime = node.InnerText;
                }
                else if (node.Name == "BIS")
                {
                    endTime = node.InnerText;
                }
            }
            return new Lecture(lectureName,startTime,endTime, day );
        }
        
    }
    class Timetable
    {
        public List<Lecture> Schedule { get; set; } = new List<Lecture>();

        public Timetable() { }

        public void PushBack(Lecture lecture)
        {
            this.Schedule.Add(lecture);
        }

        public static Timetable SetupFromXML(string filePath)
        {
            var scheduleXML = new XmlDocument();
            scheduleXML.LoadXml(filePath);

            var lectureNodes = scheduleXML.DocumentElement.ChildNodes;

            var timetable = new Timetable();

            foreach (XmlNode lectureNode in lectureNodes)
            {
                var lecture = Lecture.GetLectures(lectureNode);

                timetable.PushBack(lecture);
            }

            return timetable;
        }
    }



}
