using System;
namespace Lecture7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //initializing objects of all 3 classes
            PublisherCrosswalkSwitch publisher = new PublisherCrosswalkSwitch();
            ListenerRoad road = new ListenerRoad(publisher);
            ListenerCrossWalk crossWalk = new ListenerCrossWalk(publisher);

            // once we switch the state of the switch (by calling the method Switch), the state of both lights (road and crosswalk) changes
            System.Console.WriteLine("Pressing pedestrian crosswalk button.");
            publisher.Switch(true);
            System.Console.WriteLine("\nPressing the button again.");
            publisher.Switch(false);

        }

    }
}