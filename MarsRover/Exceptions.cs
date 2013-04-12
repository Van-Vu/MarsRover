using System;
using System.Runtime.Serialization;

namespace MarsRover
{
    /// <summary>
    /// Use this exception when the input file is not well-format
    /// </summary>
    public class InputFormatException : Exception
    {
        public InputFormatException()
            : base() { }

        public InputFormatException(string message)
            : base(message) { }

        public InputFormatException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public InputFormatException(string message, Exception innerException)
            : base(message, innerException) { }

        public InputFormatException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected InputFormatException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

    /// <summary>
    /// Use this exception when the rover's location is incorrect
    /// </summary>
    public class RoverLocationException: Exception
    {
        public RoverLocationException()
            : base() { }

        public RoverLocationException(string message)
            : base(message) { }

        public RoverLocationException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public RoverLocationException(string message, Exception innerException)
            : base(message, innerException) { }

        public RoverLocationException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected RoverLocationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }        
    }
}
