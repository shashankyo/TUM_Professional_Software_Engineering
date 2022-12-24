using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{


    public class PublisherCrosswalkButton
    {
        public bool isPressed;

        public delegate void CrosswalkButtonHandler(object source, EventArgs args);
        public event CrosswalkButtonHandler ButtonPressed;
        protected virtual void OnButtonPressed()
        {
            if (ButtonPressed != null)
                ButtonPressed(this, EventArgs.Empty);
        }

        public void PressButton()
        {
            Console.WriteLine("Switch button is now pressed.");
            isPressed = true;
            OnButtonPressed();
        }

        public void PrintCurrentState()
        {
            Console.WriteLine($"Current state of {this} is");
            Console.WriteLine(this.isPressed);
            Console.WriteLine("-------------------------");

        }

    }
}
