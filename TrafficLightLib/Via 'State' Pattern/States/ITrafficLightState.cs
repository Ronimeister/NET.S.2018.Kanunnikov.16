namespace TrafficLightLib.Via__State__Pattern
{
    /// <summary>
    /// Interface that all traffic lights states should implement
    /// </summary>
    public interface ITrafficLightState
    {
        /// <summary>
        /// Method that switch current state to the next one
        /// </summary>
        /// <param name="trafficLightCurr">current state of <see cref="TrafficLight"/></param>
        void ChangeColor(TrafficLight trafficLightCurr);
    }
}
