namespace CustomLogger
{
    /// <summary>
    /// Describe logger logic
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Write Debug message
        /// </summary>
        /// <param name="message">Message</param>
        void Debug(string message);

        /// <summary>
        /// Write Info message
        /// </summary>
        /// <param name="message">Message</param>
        void Info(string message);

        /// <summary>
        /// Write Warn message
        /// </summary>
        /// <param name="message">Message</param>
        void Warn(string message);

        /// <summary>
        /// Write Error message
        /// </summary>
        /// <param name="message">Message</param>
        void Error(string message);

        /// <summary>
        /// Fatal Error message
        /// </summary>
        /// <param name="message">Message</param>
        void Fatal(string message);       
    }
}