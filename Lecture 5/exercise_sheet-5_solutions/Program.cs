using System;

namespace Lecture5
{
    class MainClass
    {
        public static void Main(string[] argArray)
        {
            string path = "./personal_20221110_194559.xml";
            var timetable = HelperFunctions.SetUpScheduleFromXML(path);

            timetable.GetSchedule();
        }
    }
}