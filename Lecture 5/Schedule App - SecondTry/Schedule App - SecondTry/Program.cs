using System;

namespace ProSE
{
    class Program
    {
        public static void Main(string[] args)
        {

            string filePath = "D:\\WIP\\00_Akademic_TUM_ITBE\\1. Semester\\Professional Software Engineering\\Lecture 5\\Schedule App - SecondTry\\Schedule App - SecondTry\\Koray_Inal_Terminkalender_Woche.xml";
            var timetable = HelperFunctions.SetUpScheduleFromXML(filePath);

            timetable.GetSchedule();

        }
    }
}