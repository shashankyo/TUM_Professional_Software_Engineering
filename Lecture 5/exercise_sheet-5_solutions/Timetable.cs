namespace Lecture5
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
                System.Console.WriteLine($"Lectures on {day}:\n");

                GetScheduleOfDay(day);

                System.Console.WriteLine("----------------------------------------------");
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
                System.Console.WriteLine($"No lectures on {day}");
            }
        }

        private void PrintLecture(Lecture lecture)
        {
            System.Console.WriteLine($"Name:\t {lecture.Name}");
            System.Console.WriteLine($"Start Time:\t {lecture.StartTime}");
            System.Console.WriteLine($"End Time:\t {lecture.EndTime}");
            System.Console.WriteLine("\n");
        }
    }
}