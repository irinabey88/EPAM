using System;

namespace ClockLibrary
{
    /// <summary>
    /// Class listener
    /// </summary>
    public class ClockHandler
    {
        public void ShowMessage(object sender, ClockEventArgs e)
        {
            Console.WriteLine($"Clock stoped on {e.Date.ToShortDateString()}. Time interval value {e.MillisecondsToWait} milliseconds.");
        }
    }
}