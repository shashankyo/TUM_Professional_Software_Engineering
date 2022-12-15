using System;
using System.Net.Cache;
using static ProSE.Program;

namespace ProSE 
{
    public class SingepPurposeThing
    {

        public int SomeValue { get; set; }
    }
    public static class ExtensionMethods
    {
        public static void Set2Five(this SingepPurposeThing sps)
        {
            sps.SomeValue = 5;
        }
    }
    static public class ExtensionClass
    {
        static List<People> FilterPeople(List<People> set, Func<People, bool> filterFunction)
        {
            var bucket = new List<People>();

            foreach (var p in set)
            {
                if (filterFunction(p))
                {
                    bucket.Add(p);
                }
            }
            return bucket;
        }

    }
    public class People
    {
        public int Age { get; set; }
        public decimal Income { get; set; }
    }
    internal class Program
    {

        static void Set2Five(SingepPurposeThing sps)
        {
            sps.SomeValue = 5;
        }
        //static void Main(string[] args)
        //{
        //    var sps = new SingepPurposeThing();
        //    Set2Five(sps);
        //    sps.Set2Five();
        //}




        static void Main(string[] args)
        {
            var dataset = new List<People>
            {
                new People { Age = 45, Income = 35000 },
                new People { Age = 15, Income = 5000 },
                new People { Age = 42, Income = 54000 },
                new People { Age = 78, Income = 1135000 },
                new People { Age = 25, Income = 35000 },
                new People { Age = 5, Income = 35000 },
                new People { Age = 98, Income = 35000 }

            };
            //var bucket = dataset.FilterPeople(people => people.Age > 60);

            var bucket = dataset.Where(p => p.Age > 30).First();

            // var bucket = FilterPeople(dataset);
            foreach (var p in bucket)
            {
                Console.WriteLine("The age is " + p.Age.ToString());
            }
        }
    }
}