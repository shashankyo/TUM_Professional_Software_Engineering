using System;
using System.Data.Common;

namespace ProSE
{
    class LiveCodingClass
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            Dog dog= new Dog();
            Cat cat = new Cat();

            animal.MakeSound();
            dog.MakeSound();
            cat.MakeSound();

            Animal cloned_dog = (Animal)dog;
            Animal cloned_cat = (Animal)cat;
        }


    }
}