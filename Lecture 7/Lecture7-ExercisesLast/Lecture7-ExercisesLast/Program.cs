using System;
using System.ComponentModel;

namespace ProSE
{
    class Program
    {
        public delegate void AdditionHandler<T>(T firstArg, T secondArg);

        public Type Add(Type firstArg, Type secondArg)
        {
            return firstArg+secondArg+;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Main program..");

            AdditionHandler delegateFirst = Add;
            
            
        }
    }
}