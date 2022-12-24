using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class ListenerCrosswalkLight
    {
        public bool hasGreen = true;
        public void OnButtonPressed(object o, EventArgs e)
        {
            Console.WriteLine("Crosswalk lights has received the button message...");
            if (hasGreen == false)
            {
                hasGreen = true;

            }
            else
            {
                hasGreen = false;
            }
            PrintCurrentState();
        }
        public void PrintCurrentState()
        {
            Console.WriteLine($"Current state of {this} is");
            Console.WriteLine(this.hasGreen);
            Console.WriteLine("-------------------------");

        }

    }
}
