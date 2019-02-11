using IfCompanyTask.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace IfCompanyTask.Exceptions.ApiExceptions
{
    /// <summary>
    /// The InternalServerErrorException
    /// </summary>
    /// <seealso cref="IfCompanyTask.Exceptions.Base.BaseException" />
    public class InternalServerErrorException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorException"/> class.
        /// </summary>
        public InternalServerErrorException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public InternalServerErrorException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public InternalServerErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected InternalServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
