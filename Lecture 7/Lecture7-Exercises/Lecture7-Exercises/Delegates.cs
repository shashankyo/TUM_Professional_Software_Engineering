using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProSE.Delegates;

namespace ProSE
{

    class Delegates
    {
        public delegate int AdditionHandler();
        static int Add(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            AdditionHandler op = new AdditionHandler(Add);
            Console.WriteLine(op(10, 5));
            Console.ReadLine();

        }
        //public delegate Type AdditionHandler();

        //public  Type Add(Type firstArg, Type secondArg)
        //{

        //    return firstArg + secondArg;

        //}




        //AdditionHandler additionHandlerFirst = new AdditionHandler(Add);
        //AdditionHandler additionHandlerSecond = new AdditionHandler(Add);
        //AdditionHandler additionHandlerThird = new AdditionHandler(Add);




    }


}
