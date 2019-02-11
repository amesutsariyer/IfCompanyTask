using IfCompanyTask.Exceptions.Base;
using System;
using System.Runtime.Serialization;

namespace IfCompanyTask.Exceptions.ApiExceptions
{
    /// <summary>
    /// The NotNullException
    /// </summary>
    /// <seealso cref="IfCompanyTask.Exceptions.Base.BaseException" />
    public class NotNullException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotNullException"/> class.
        /// </summary>
        public NotNullException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotNullException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public NotNullException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotNullException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public NotNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotNullException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected NotNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
