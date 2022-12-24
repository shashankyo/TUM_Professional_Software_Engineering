using System;

namespace Lecture7
{
    public class ListenerRoad
    {
        public PublisherCrosswalkSwitch publisher; //create an object of the event publisher
        public ListenerRoad(PublisherCrosswalkSwitch publisher)
        {
            this.publisher = publisher;
            this.publisher.SwitchPress += TrafficLightState; //adding method to the publisher's event delegate
        }
        void TrafficLightState(object sender, bool switchState) // printing state of light (sender will be an object of PublisherCrosswalkSwitch)
        {
            if (switchState)
            {
                Console.WriteLine("Traffic Light is Red.");
            }
            else
            {
                Console.WriteLine("Traffic Light is Green.");
            }

        }
    }
}