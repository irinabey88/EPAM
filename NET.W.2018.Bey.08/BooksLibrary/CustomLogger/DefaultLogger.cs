namespace CustomLogger
{
    using System;

    using Serilog;
    using Serilog.Events;

    public class DefaultLogger : ILogger
    {
        public DefaultLogger()
        {
            new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(LogEventLevel.Information)
                .WriteTo.RollingFile(_baseDir + "\\log-{Date}.txt", LogEventLevel.Debug)
                .CreateLogger();
        }

        private static string _baseDir = AppDomain.CurrentDomain.BaseDirectory;

        public void Debug(string message)
        {
            Log.Debug($"Debug message: {message} ");
        }

        public void Info(string message)
        {
            Log.Information($"Info message: {message} ");
        }

        public void Warn(string message)
        {
            Log.Warning($"Warning message: {message} ");
        }

        public void Error(string message)
        {
            Log.Error($"Error message: {message} ");
        }

        public void Fatal(string message)
        {
            Log.Information($"Fatal message: {message} ");
        }
    }
}