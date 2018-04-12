namespace CustomLogger
{
    using System;

    public static class BookLogger
    {      
        private static ILogger _defaulLogger = new DefaultLogger();

        private static ILogger _customLogger;

        public static void Debug(string message)
        {
            if (_customLogger == null)
            {
                _defaulLogger.Debug(message);
            }
            else
            {
                _customLogger.Debug(message);
            }
        }

        public static void Info(string message)
        {
            if (_customLogger == null)
            {
                _defaulLogger.Info(message);
            }
            else
            {
                _customLogger.Info(message);
            }
        }

        public static void Warn(string message)
        {
            if (_customLogger == null)
            {
                _defaulLogger.Warn(message);
            }
            else
            {
                _customLogger.Warn(message);
            }
        }

        public static void Error(string message)
        {
            if (_customLogger == null)
            {
                _defaulLogger.Error(message);
            }
            else
            {
                _customLogger.Error(message);
            }
        }

        public static void Fatal(string message)
        {
            if (_customLogger == null)
            {
                _defaulLogger.Fatal(message);
            }
            else
            {
                _customLogger.Fatal(message);
            }
        }

        public static void SetUp(ILogger customLogger)
        {
            try
            {
                if (customLogger == null)
                {
                    _defaulLogger.Error($"ArgumentNullException {nameof(customLogger)} is null");

                    throw new ArgumentNullException(nameof(customLogger));
                }

                _customLogger = customLogger;
            }
            catch (ArgumentNullException)
            {
                _defaulLogger.Warn($"CustomLogger wasn't setup !");
            }           
        }

        public static void Close()
        {
        }
    }
}