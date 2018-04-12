namespace CustomLogger
{
    using NLog;

    public class DefaultLogger : ILogger
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
      
        public void Debug(string message)
        {
            _logger.Debug($"Debug message: {message} ");         
        }

        public void Info(string message)
        {
            _logger.Info($"Info message: {message} ");            
        }

        public void Warn(string message)
        {
            _logger.Warn($"Warning message: {message} ");            
        }

        public void Error(string message)
        {
            _logger.Error($"Error message: {message} ");            
        }

        public void Fatal(string message)
        {
            _logger.Fatal($"Fatal message: {message} ");            
        }       
    }
}