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

            Lecture.Set(filePath);
            Lecture.GetLectures(filePath);

        }
    }
}