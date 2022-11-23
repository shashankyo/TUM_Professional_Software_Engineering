using ProSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    class Animal
    {
        public Animal()
        {
                public virtual void MakeSound()
            {
                Console.WriteLine("Make some animal sound...");
            }
        }
     
    }
    class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("woof woof");
    }
    class Cat : Animal
    {
        public new void MakeSound()
        {
            Console.WriteLine("meow meow");
        }
    }
    // Abstract
    public abstract class AbstractAnimal
    {
        public abstract void MakeAbstractSound();
        public virtual void MakeSound()
        {
            Console.WriteLine("Make some animal sound...");
        }
    }
    public class AbstractDog : AbstractAnimal
    {
        public override void MakeAbstractSound()
        {
            Console.WriteLine("Abstract Sound")
        }
    }

}



