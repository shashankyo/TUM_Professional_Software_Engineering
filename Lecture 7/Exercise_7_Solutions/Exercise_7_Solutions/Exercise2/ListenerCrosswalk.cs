using System;

namespace Lecture7
{
    public class ListenerCrossWalk
    {
        public PublisherCrosswalkSwitch publisher; //create an object of the event publisher
        public ListenerCrossWalk(PublisherCrosswalkSwitch publisher)
        {
            this.publisher = publisher;
            this.publisher.SwitchPress += CrossWalkLightState; //adding method to the publisher's event delegate
        }
        void CrossWalkLightState(object sender, bool switchState) // printing state of light (sender will be an object of PublisherCrosswalkSwitch)
        {
            if (switchState)
            {
                Console.WriteLine("Cross-walk Light is Green.");
            }
            else
            {
                Console.WriteLine("Cross-walk Light is Red.");
            }

        }
    }

}