using System;
namespace ProSE
{
    class Phone
    {
        public int age;
        public string model_name;

        // constructor
        public Phone()
        {
            Console.WriteLine("calling default constructor");
        }
        public Phone(int age_init)
        {
            this.age= age_init;
            Console.WriteLine("calling age constructor");
        }


    }
}