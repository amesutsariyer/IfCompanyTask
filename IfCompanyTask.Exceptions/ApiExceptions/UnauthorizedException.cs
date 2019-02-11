using IfCompanyTask.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace IfCompanyTask.Exceptions.ApiExceptions
{
    /// <summary>
    /// The UnauthorizedException
    /// </summary>
    /// <seealso cref="IfCompanyTask.Exceptions.Base.BaseException" />
    public class UnauthorizedException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
        /// </summary>
        public UnauthorizedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public UnauthorizedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
