using System;

namespace ProSE
{
    class MainClass
    {
        static void Main(string[] argArray)
        {
            Console.WriteLine("Hello Dining Philosphers");
            int numPhilosophers = 5;

            // Construct philosophers and chopsticks
            var philosophers = Helpers.InitPhilosophers(numPhilosophers);

            // Start dinner
            Console.WriteLine("Dinner is starting!");

            // Spawn threads for each philosopher's eating cycle
            var philosopherThreads = new List<Thread>();
            foreach (var philosopher in philosophers)
            {
                var philosopherThread = new Thread(new ThreadStart(philosopher.EatAll));
                philosopherThreads.Add(philosopherThread);
                philosopherThread.Start();
            }

            // Wait for all philosopher's to finish eating
            foreach (var thread in philosopherThreads)
            {
                thread.Join();
            }

            // Done
            Console.WriteLine("Dinner is over!");
        }
    }
}