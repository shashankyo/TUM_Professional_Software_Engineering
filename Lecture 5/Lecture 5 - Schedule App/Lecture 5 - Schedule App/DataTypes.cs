using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public enum Days
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
    }
    public class Lecture
    {
        public string startTime; 
        public string endTime;
        public string lectureName;
        public string lectureDay;
        
    }
    public class Timetable
    {
        public Lecture timetableLecture;
        public string owner;

        public Timetable(Lecture timetableLecture, string owner)
        {
            this.timetableLecture = timetableLecture;
            this.owner = owner;
        }




    }
}
