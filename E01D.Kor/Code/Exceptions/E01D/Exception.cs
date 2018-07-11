using System;
using System.Runtime.Serialization;

namespace Root.Code.Exceptions.E01D
{
    public class Exception:System.Exception, Exception_I
    {
        /// <summary>
        /// Creates a new exception
        /// </summary>
        public Exception()
        {

        }

        /// <summary>
        /// Creates a new exception with the following message.
        /// </summary>
        /// <param name="message"></param>
        public Exception(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new exception with the following message and inner exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public Exception(String message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Creates a new exception with the following message and inner exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public Exception(String message, System.Exception innerException)
            : base(message, innerException)
        {

        }

        public Exception(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string TypeName { get; set; } = "Exception";

        /// <summary>
        /// Gets or sets the classification code associated with this exception.  This allows for the exception t
        /// </summary>
        public long TypeId { get; set; }
    }
}
