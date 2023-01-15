using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    static class PiCalculators
    {
        //series LINQ
        public static double SerialLinqPi(int numberOfSteps)
        {
            double stepSize = 1.0 / (double) numberOfSteps;

            return (
                from i in Enumerable.Range(0, numberOfSteps)
                let x = (i + 0.5) * stepSize
                select 4.0 / (1.0 + x * x)).Sum() * stepSize;
        }
        // parallel LINQ
        public static double ParallelLinqPi(int numberOfSteps)
        {
            double stepSize = 1.0 / (double)numberOfSteps;

            return (
                from i in ParallelEnumerable.Range(0, numberOfSteps)
                let x = (i + 0.5) * stepSize
                select 4.0 / (1.0 + x * x)).Sum() * stepSize;
        }

        // series for loop
        public static double SerialPi(int numberOfSteps)
        {
            double sum = 0;

            double stepSize = 1.0 / (double)numberOfSteps;
            
            for (int i=0; i<numberOfSteps; i++)
            {
                double x = (i + 0.5) * stepSize;
                sum += 4.0 / (1.0 + x * x);
            }

            return stepSize * sum;
        }
        // parallel for loop

        public static double ParallelPi(int numberOfSteps)
        {
            double sum = 0;

            double stepSize = 1.0 / (double)numberOfSteps;

            object monitor = new object();

            Parallel.For(0, numberOfSteps, () => 0.0, (i, state, local) =>
            {
                double x = (i + 0.5) * stepSize;
                return local + 4.0 / (1.0 + x * x);
            } , local => { lock(monitor) sum += local; }
            );

            return stepSize * sum;
        }
    }
}
