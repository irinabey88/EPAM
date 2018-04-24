using System;
using System.Runtime.Serialization;

namespace BLL.Exceptions
{
    [Serializable]
    public class UriException : Exception
    {
        public UriException() : base()
        {
        }

        public UriException(string message) : base(message)
        {
        }

        public UriException(string message, Exception inner) : base(message, inner)
        {
        }

        public UriException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}