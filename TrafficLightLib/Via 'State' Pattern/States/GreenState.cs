using System;

namespace TrafficLightLib.Via__State__Pattern
{
    /// <summary>
    /// <see cref="ITrafficLightState"/> green state representation
    /// </summary>
    internal class GreenState : ITrafficLightState
    {
        /// <summary>
        /// Change current <paramref name="trafficLight"/> color state
        /// </summary>
        /// <param name="trafficLight">current <paramref name="trafficLight"/></param>
        public void ChangeColor(TrafficLight trafficLight)
        {
            Console.WriteLine("Changed to green color.");
            trafficLight.State = new YellowState(this);
        }
    }
}
