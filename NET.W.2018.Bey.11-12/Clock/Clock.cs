namespace ClockLibrary
{
    using System.Threading;

    public class Clock
    {
        private const int MILISECONDS = 1000;

        private readonly int _timeToWait;

        public Clock(int seconds)
        {
            _timeToWait = seconds * MILISECONDS;
        }

        public delegate void ClockEventHandler(object sender, ClockEventArgs e);

        public event ClockEventHandler Tick;

        public void Start()
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(_timeToWait);               
                OnTick(this, new ClockEventArgs(_timeToWait));
            });

            thread.Start();
        }

        protected virtual void OnTick(object sender, ClockEventArgs e)
        {
            Tick?.Invoke(sender, e);
        }
    }
}