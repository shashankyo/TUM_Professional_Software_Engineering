using SProSE;
using System;


namespace ProSE
{
    class Lecture
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DaysOfTheWeek Day { get; set; }
        public string Name { get; set; }

        private Lecture() { }

        public Lecture(string startTime, string endTime, DaysOfTheWeek day, string name)
        {
            Day = day;
            Name = name;

            bool isValidStart = DateTime.TryParse(startTime, out _);
            bool isValidEnd = DateTime.TryParse(endTime, out _);

            if (isValidStart && isValidEnd)
            {
                this.StartTime = startTime;
                this.EndTime = endTime;
            }
            else
            {
                this.StartTime = "12:00 AM";
                this.EndTime = "01:00 AM";

                Console.WriteLine("Invalid time. Using a default time of 12:00 and a druation of 1 hour");
            }
        }
    }
}
