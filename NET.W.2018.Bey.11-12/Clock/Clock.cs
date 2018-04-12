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

        public delegate void ClockEventHandler(object sender, ClockEventArgs e);

        public event ClockEventHandler Tick;

        /// <summary>
        /// Method starting timer
        /// </summary>
        public void Start()
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(_timeToWait);               
                OnTick(this, new ClockEventArgs(_timeToWait));
            });

            thread.Start();
        }

        /// <summary>
        /// Methods that calls event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnTick(object sender, ClockEventArgs e)
        {
            Tick?.Invoke(sender, e);
        }
    }
}