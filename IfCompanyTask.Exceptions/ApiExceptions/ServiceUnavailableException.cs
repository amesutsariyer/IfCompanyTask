using IfCompanyTask.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace IfCompanyTask.Exceptions.ApiExceptions
{
    /// <summary>
    /// The ServiceUnavailableException
    /// </summary>
    /// <seealso cref="IfCompanyTask.Exceptions.Base.BaseException" />
    public class ServiceUnavailableException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnavailableException"/> class.
        /// </summary>
        public ServiceUnavailableException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnavailableException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ServiceUnavailableException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnavailableException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ServiceUnavailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnavailableException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected ServiceUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
