namespace Lecture5
{
    class Lecture
    {
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DaysOfTheWeek Day { get; set; }

        private Lecture() { }

        public Lecture(string name, string startTime, string endTime, DaysOfTheWeek day)
        {
            this.Name = name;
            this.Day = day;

            bool isValidStart = DateTime.TryParse(startTime, out _);
            bool isValidEnd = DateTime.TryParse(endTime, out _);

            if (isValidStart && isValidEnd)
            {
                this.StartTime = startTime;
                this.EndTime = endTime;
            }
            else
            {
                Console.Write("Invalid time. Setting start time to 12:00am and duration to 1 hour.\n");

                this.StartTime = "12:00 AM";
                this.EndTime = "1:00 AM";
            }

        }
    }
}