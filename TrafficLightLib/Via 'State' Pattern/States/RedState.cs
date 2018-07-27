using System;

namespace TrafficLightLib.Via__State__Pattern
{
    /// <summary>
    /// <see cref="ITrafficLightState"/> red state representation
    /// </summary>
    internal class RedState : ITrafficLightState
    {
        /// <summary>
        /// Change current <paramref name="trafficLight"/> color state
        /// </summary>
        /// <param name="trafficLight">current <paramref name="trafficLight"/></param>
        public void ChangeColor(TrafficLight trafficLight)
        {
            Console.WriteLine("Changed to red color.");
            trafficLight.State = new YellowState(this);
        }
    }
}
