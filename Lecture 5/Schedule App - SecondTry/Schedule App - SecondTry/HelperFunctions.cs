using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;
using SProSE;

namespace ProSE
{
    static class HelperFunctions
    {
        public static Timetable SetUpScheduleFromXML (string path)
        {
            string filePath = "D:\\WIP\\00_Akademic_TUM_ITBE\\1. Semester\\Professional Software Engineering\\Lecture 5\\Schedule App - SecondTry\\Schedule App - SecondTry";

            var scheduleXML = new XmlDocument ();
            scheduleXML.LoadXml (filePath);

            var timetable = new Timetable ();


            //TODO take all the lectures from xml and pushback --> timetable

            var lectureNodes = scheduleXML.DocumentElement.ChildNodes;

            foreach (XmlNode lectureNode in lectureNodes)
            {
                var lecture = HelperFunctions.GetLectureInfo(lectureNode); //wip

                timetable.PushBack(lecture);
            }

            return timetable;
        }

        private static Lecture GetLectureInfo(XmlNode lectureNode)
        {
            string name = " ", startTime = " ", endTime = " ";
            DaysOfTheWeek day = DaysOfTheWeek.Sunday;

            foreach (XmlNode node in lectureNode)
            {
                if (node.Name == "TITEL")
                {
                    name = node.InnerText;
                }
                else if (node.Name == "VON")
                {
                    startTime = node.InnerText;
                }
                else if (node.Name == "BIS")
                {
                    endTime = node.InnerText;
                }
                else if (node.Name == "DATUM")
                {
                    // 14.11.2022 --> monday, tuesday etc.
                    var deCultureInfo = new CultureInfo("de-DE");
                    DateTime dateValue = DateTime.ParseExact(node.InnerText, "dd.MM.yyyy", deCultureInfo);

                    bool isValidDay = Enum.TryParse(dateValue.ToString("dddd"), out day);
                    
                }
            }
            return new Lecture(startTime, endTime, day, name);
        }
    }
}
