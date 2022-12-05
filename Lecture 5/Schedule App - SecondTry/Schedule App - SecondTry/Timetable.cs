using SProSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    class Timetable
    {
        public List<Lecture> Schedule { get; set; } = new List<Lecture>();

        public Timetable() { }

        public void PushBack(Lecture lecture)
        {
            this.Schedule.Add(lecture);
        }
        public void GetSchedule()
        {
            foreach (DaysOfTheWeek day in Enum.GetValues(typeof(DaysOfTheWeek)))
            {
                Console.WriteLine($"Lectures on {day}: \n");
                
                GetScheduleOfDay(day);

                Console.WriteLine("--------------------------------------------------");
            }
        }

        public void GetScheduleOfDay(DaysOfTheWeek day)
        {
            bool isFreeDay = true;

            foreach (var lecture in this.Schedule)
            {
                if (lecture.Day == day)
                {
                    isFreeDay = false;

                    this.PrintLecture(lecture);

                }
            }
            if (isFreeDay)
            {
                Console.WriteLine($" No lectures on {day}");
            }
        }
        private void PrintLecture(Lecture lecture)
        {
            Console.WriteLine($"Name: \t {lecture.Name}");
            Console.WriteLine($"Start Time: \t {lecture.StartTime}");
            Console.WriteLine($"End Time: \t {lecture.EndTime}");
            Console.WriteLine($"Day: \t {lecture.Day}");

            Console.WriteLine("\n");
        }

    }
}
