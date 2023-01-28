using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTest
{
    public class MyClass
    {
        private int classVariable;
        private Object myLock = new Object();
        public void printVariables(Object parameterVariable)
        {
            lock (myLock)
            {
                this.classVariable = Convert.ToInt32(parameterVariable);

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine(this.classVariable + "  " + parameterVariable);
                }
            }

        }

    }
}
