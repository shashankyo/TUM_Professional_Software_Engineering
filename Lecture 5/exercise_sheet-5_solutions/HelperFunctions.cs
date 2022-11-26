using System.Xml;
using System.Globalization;

namespace Lecture5
{
    static class HelperFunctions
    {
        public static Timetable SetUpScheduleFromXML(string path)
        {
            var scheduleXML = new XmlDocument();
            scheduleXML.Load(path);

            var timetable = new Timetable();

            var lectureNodes = scheduleXML.DocumentElement.ChildNodes;

            foreach (XmlNode lectureNode in lectureNodes)
            {
                var lecture = HelperFunctions.GetLectureInfo(lectureNode);

                timetable.PushBack(lecture);
            }

            return timetable;
        }

        private static Lecture GetLectureInfo(XmlNode lecture)
        {
            string name = " ", startTime = " ", endTime = " ";
            DaysOfTheWeek day = DaysOfTheWeek.Sunday;

            foreach (XmlNode node in lecture)
            {
                if (node.Name == "TITEL")
                {
                    name = node.InnerText;
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

            return new Lecture(name, startTime, endTime, day);
        }
    }
}