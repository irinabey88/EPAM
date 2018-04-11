namespace ClockLibrary
{
    using System;

    public class ClockEventArgs : EventArgs
    {
        private int _milliMillisecondsToWait;

        public ClockEventArgs(int milliMilliseconds)
        {
            this._milliMillisecondsToWait = milliMilliseconds;
        }

        public DateTime Date { get; set; } = DateTime.Now;

        public int MillisecondsToWait
        {
            get => this._milliMillisecondsToWait;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Count of  miliseconds should be greater than 0");
                }

                this._milliMillisecondsToWait = value;
            }
        }
    }
}
