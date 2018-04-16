namespace ClockConsole
{
    using System;
    using ClockLibrary;

    public class Program
    {
        public static void Main(string[] args)
        {
            Clock clock = new Clock(13);
            ClockHandler handler = new ClockHandler();
            clock.ClockTick += handler.ShowMessage;

            clock.Start();

            Console.ReadKey();
        }
    }
}
