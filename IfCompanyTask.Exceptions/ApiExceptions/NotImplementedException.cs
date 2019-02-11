using IfCompanyTask.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace IfCompanyTask.Exceptions.ApiExceptions
{
    /// <summary>
    /// The NotImplementedException
    /// </summary>
    /// <seealso cref="IfCompanyTask.Exceptions.Base.BaseException" />
    public class NotImplementedException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotImplementedException"/> class.
        /// </summary>
        public NotImplementedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotImplementedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public NotImplementedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotImplementedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public NotImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotImplementedException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected NotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
