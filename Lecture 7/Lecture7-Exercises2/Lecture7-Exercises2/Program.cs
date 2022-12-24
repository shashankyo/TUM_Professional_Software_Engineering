using System;
namespace ProSE
{
    class FirstClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Traffic Lights...\nAmpeln auf Deutsch");

            var switchButton = new PublisherCrosswalkButton(); // publisher
            var crosswalkLight = new ListenerCrosswalkLight(); // subscribeer
            var trafficLight = new ListenerTrafficLight(); // subscriber

            // subscriptions
            switchButton.ButtonPressed += crosswalkLight.OnButtonPressed;
            switchButton.ButtonPressed += trafficLight.OnButtonPressed;

            // current state of the objects hasGreen status
            switchButton.PrintCurrentState();
            crosswalkLight.PrintCurrentState();
            trafficLight.PrintCurrentState();

            // after the button is pressed
            switchButton.PressButton();
        }
    }
}