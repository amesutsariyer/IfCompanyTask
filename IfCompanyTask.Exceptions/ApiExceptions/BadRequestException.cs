using IfCompanyTask.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace IfCompanyTask.Exceptions.ApiExceptions
{
    /// <summary>
    /// The BadRequestException
    /// </summary>
    /// <seealso cref="IfCompanyTask.Exceptions.Base.BaseException" />
    public class BadRequestException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        public BadRequestException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public BadRequestException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
