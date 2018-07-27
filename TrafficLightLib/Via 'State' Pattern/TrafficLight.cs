using System.Threading;

namespace TrafficLightLib.Via__State__Pattern
{
    /// <summary>
    /// Class that implement traffic light logic
    /// </summary>
    public class TrafficLight
    {
        /// <summary>
        /// Current state of traffic light
        /// </summary>
        public ITrafficLightState State { get; set; }

        /// <summary>
        /// Standart ctor for <see cref="TrafficLight"/>
        /// </summary>
        public TrafficLight()
        {
            State = new GreenState();
        }

        /// <summary>
        /// Change current <see cref="State"/>
        /// </summary>
        public void ChangeState()
        {
            State.ChangeColor(this);
            Thread.Sleep(900);
        }
    }
}
