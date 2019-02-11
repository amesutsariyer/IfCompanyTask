using IfCompanyTask.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace IfCompanyTask.Exceptions.ApiExceptions
{
    /// <summary>
    /// The ForbiddenException
    /// </summary>
    /// <seealso cref="IfCompanyTask.Exceptions.Base.BaseException" />
    public class ForbiddenException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        public ForbiddenException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ForbiddenException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ForbiddenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
