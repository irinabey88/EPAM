using System;

namespace ClockLibrary
{
    public class ClockHandler
    {
        public void ShowMessage(object sender, ClockEventArgs e)
        {
            Console.WriteLine($"Clock stoped on {e.Date.ToShortDateString()}. Time interval value {e.MillisecondsToWait} milliseconds.");
        }
    }
}