using IfCompanyTask.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace IfCompanyTask.Exceptions.ApiExceptions
{
    /// <summary>
    /// The BadGatewayException
    /// </summary>
    /// <seealso cref="IfCompanyTask.Exceptions.Base.BaseException" />
    public class BadGatewayException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadGatewayException"/> class.
        /// </summary>
        public BadGatewayException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadGatewayException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public BadGatewayException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadGatewayException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public BadGatewayException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadGatewayException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected BadGatewayException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
