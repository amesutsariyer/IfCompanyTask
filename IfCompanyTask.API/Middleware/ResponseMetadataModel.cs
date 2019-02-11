using System;
using System.Net;

namespace IfCompanyTask.API.Middlewares
{
    /// <summary>
    /// The ResponseMetadata
    /// </summary>
    public class ResponseMetadataModel
    {
        /// <summary>
        /// Gets the identifier request.
        /// </summary>
        /// <value>
        /// The identifier request.
        /// </value>
        public string IDRequest { get; }
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version { get; set; } = "1.0.0";
        /// <summary>
        /// Gets or sets the user error message.
        /// </summary>
        /// <value>
        /// The user error message.
        /// </value>
        public string UserErrorMessage { get; set; }
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTimeOffset DateTimeOffsetUtc { get; set; }
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public long? Size { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ResponseMetadataModel" /> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseMetadataModel" /> class.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public object Result { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseMetadataModel" /> class.
        /// </summary>
        public ResponseMetadataModel()
        {
            IDRequest         = Guid.NewGuid().ToString();
            DateTimeOffsetUtc = DateTimeOffset.UtcNow;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseMetadataModel" /> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="result">The result.</param>
        /// <param name="userErrorMessage">The user error message.</param>
        /// <param name="errorMessage">The error message.</param>
        public ResponseMetadataModel(HttpStatusCode statusCode, object result = null, string userErrorMessage = null, string errorMessage = null)
        {
            IDRequest         = Guid.NewGuid().ToString();
            StatusCode        = statusCode;
            Result            = result;
            UserErrorMessage  = UserErrorMessage;
            ErrorMessage      = errorMessage;
            DateTimeOffsetUtc = DateTimeOffset.UtcNow;
            Success           = true;
        }
        /// <summary>
        /// Creates the specified status code.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="result">The result.</param>
        /// <param name="userErrorMessage">The user error message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static ResponseMetadataModel Create(HttpStatusCode statusCode, object result = null, string userErrorMessage = null, string errorMessage = null)
        {
            return new ResponseMetadataModel(
                statusCode      : statusCode, 
                result          : result, 
                userErrorMessage: userErrorMessage, 
                errorMessage    : errorMessage);
        }
    }
}
