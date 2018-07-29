using System;
using System.Threading;

namespace TrafficLightLib.Via_delegate
{
    /// <summary>
    /// Traffic light implementation via delegate
    /// </summary>
    public class TrafficLight
    {
        #region Constants
        private const int LOOPS_BY_DEFAULT = 3;
        private const int RED_LIGHT_DELAY = 1900;
        private const int YELLOW_LIGHT_DELAY = 950;
        private const int GREEN_LIGHT_DELAY = 1500;
        private readonly int _loops;
        #endregion

        #region Private fields and delegate
        private delegate void LightStateHandler();
        private ConsoleColor _currentColor;
        #endregion

        #region .ctors
        /// <summary>
        /// .ctor for <see cref="TrafficLight"/> class
        /// </summary>
        public TrafficLight()
        {
            _loops = LOOPS_BY_DEFAULT;
        }

        /// <summary>
        /// .ctor for <see cref="TrafficLight"/> class
        /// </summary>
        /// <param name="loops">Number of loops</param>
        /// <exception cref="ArgumentException">Throws when <paramref name="loops"/> is less than 1</exception>
        public TrafficLight(int loops)
        {
            if (loops <= 0)
            {
                throw new ArgumentException($"{nameof(loops)} can't be less than 1!");
            }

            _loops = loops;
        }
        #endregion

        #region Public API
        /// <summary>
        /// Start the traffic light activity
        /// </summary>
        public void Run()
        {
            LightStateHandler fromRedToGreen = SwitchToRed;
            fromRedToGreen += SwitchToYellow;

            LightStateHandler fromGreenToRed = SwitchToGreen;
            fromGreenToRed += SwitchToYellow;

            RunInner(fromRedToGreen, fromGreenToRed);
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion

        #region Private methods
        private void RunInner(LightStateHandler fromRedToGreen, LightStateHandler fromGreenToRed)
        {
            for (int i = 0; i < _loops; i++)
            {
                fromRedToGreen.Invoke();
                fromGreenToRed.Invoke();
            }
        }

        private void SwitchToRed()
        {
            SetCurrentColor(ConsoleColor.Red);
            Thread.Sleep(RED_LIGHT_DELAY);
        }

        private void SwitchToYellow()
        {
            SetCurrentColor(ConsoleColor.Yellow);
            Thread.Sleep(YELLOW_LIGHT_DELAY);
        }

        private void SwitchToGreen()
        {
            SetCurrentColor(ConsoleColor.Green);
            Thread.Sleep(GREEN_LIGHT_DELAY);
        }

        private void SetCurrentColor(ConsoleColor color)
        {
            _currentColor = color;
            Console.ForegroundColor = _currentColor;
            Console.WriteLine($"Switched to {_currentColor.ToString()}");
        }
        #endregion
    }
}