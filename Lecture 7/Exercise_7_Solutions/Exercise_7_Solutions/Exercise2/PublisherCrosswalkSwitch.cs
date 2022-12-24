using System;

namespace Lecture7
{
    public class PublisherCrosswalkSwitch
    {
        public delegate void SwitchPressHandler(object sender, bool switchState); // declare delegate for SwitchPress
        public event SwitchPressHandler SwitchPress; //init event

        //! this will look slightly different from examples you see on the internet since we used a simple boolean as our event argument instead of the EventArgs class
        protected virtual void OnSwitchPress(bool switchState)
        {
            if (SwitchPress != null)
            {
                SwitchPress(this, switchState); // call event if there are subscribers to event
            }
        }

        public void Switch(bool switchState) // Prints the state of the switch/button
        {
            if (switchState)
            {
                System.Console.WriteLine("Button is pressed.");
            }
            else
            {
                System.Console.WriteLine("Button is off.");
            }
            OnSwitchPress(switchState); // check for subscribers then call event
        }
    }
}
