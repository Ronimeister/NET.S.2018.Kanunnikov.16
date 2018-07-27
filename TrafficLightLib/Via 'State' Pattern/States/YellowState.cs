using System;

namespace TrafficLightLib.Via__State__Pattern
{
    /// <summary>
    /// 
    /// </summary>
    internal class YellowState : ITrafficLightState
    {
        private ITrafficLightState _previousState;

        /// <summary>
        /// Ctor for <see cref="YellowState"/> that takes previous <see cref="TrafficLight"/> state
        /// </summary>
        /// <param name="state">previous <see cref="TrafficLight"/> state</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="state"/> is equal to null</exception>
        public YellowState(ITrafficLightState state)
        {
            _previousState = state ?? throw new ArgumentNullException($"{nameof(state)} can't be equal to null!");
        }

        /// <summary>
        /// Change current <paramref name="trafficLight"/> color state
        /// </summary>
        /// <param name="trafficLight">current <paramref name="trafficLight"/></param>
        public void ChangeColor(TrafficLight trafficLight)
        {
            Console.WriteLine("Changed to yellow color.");
            if (_previousState.GetType() == typeof(RedState))
            {
                trafficLight.State = new GreenState();
            }
            else
            {
                trafficLight.State = new RedState();
            }
        }
    }
}
