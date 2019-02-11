using IfCompanyTask.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace IfCompanyTask.Exceptions.ApiExceptions
{
    /// <summary>
    /// The RequestTimeoutException
    /// </summary>
    /// <seealso cref="IfCompanyTask.Exceptions.Base.BaseException" />
    public class RequestTimeoutException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTimeoutException"/> class.
        /// </summary>
        public RequestTimeoutException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTimeoutException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public RequestTimeoutException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTimeoutException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RequestTimeoutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestTimeoutException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected RequestTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
