using System;

namespace ClockLibrary
{
    using System.Threading;

    /// <summary>
    /// Class that provides events
    /// </summary>
    public class Clock
    {
        private const int MILISECONDS = 1000;

        private readonly int _timeToWait;

        /// <summary>
        /// Provides the instance of class <see cref="Clock"/>
        /// </summary>
        /// <param name="seconds"></param>
        public Clock(int seconds)
        {
            _timeToWait = seconds * MILISECONDS;
        }        

        public event EventHandler<ClocTickEventArgs> ClockTick;

        /// <summary>
        /// Method starting timer
        /// </summary>
        public void Start()
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(_timeToWait);               
                OnClockTick(this, new ClocTickEventArgs(_timeToWait));
            });

            thread.Start();
        }

        /// <summary>
        /// Methods that calls event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnClockTick(object sender, ClocTickEventArgs e)
        {
            ClockTick?.Invoke(sender, e);
        }
    }
}