
using IfCompanyTask.Exceptions.ApiExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.API.Middlewares
{
    /// <summary>
    /// The Global Exception Middleware
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate _next;
        /// <summary>
        /// The log
        /// </summary>
        private readonly Serilog.ILogger Log = Serilog.Log.ForContext<ResponseMetadataMiddleware>();
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <exception cref="ArgumentNullException">next</exception>
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }
        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Response != null)
            {
                var responseBody = context.Response.Body;
                try
                {
                    await _next.Invoke(context);


                }
                catch (Exception Ex)
                {
                    context.Response.Body = responseBody;
                    await HandleExceptionAsync(context, Ex);
                }
            }
        }

        /// <summary>
        /// Handles the exception asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = new ResponseMetadataModel();

            context.Response.ContentType = "application/json";

            #region Exception

            if (exception is BadGatewayException)
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "Bad Gateway.Please Try Again Later.");
                result.Result = null;
                result.StatusCode = HttpStatusCode.BadGateway;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.BadGateway;
            }
            else if (exception is BadRequestException)
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "Bad Request.Please Check Your Request Model.");
                result.Result = null;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (exception is ForbiddenException)
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "Authentication Failure");
                result.Result = null;
                result.StatusCode = HttpStatusCode.Forbidden;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else if (exception is InternalServerErrorException)
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "Something Went Wrong.Please Try Again Later");
                result.Result = null;
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else if (exception is NotFoundException)
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "Can not found.");
                result.Result = null;
                result.StatusCode = HttpStatusCode.NotFound;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
       
            else if (exception is NotNullException)
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "Value can not be null");
                result.Result = null;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (exception is RequestTimeoutException)
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "Request timeout.");
                result.Result = null;
                result.StatusCode = HttpStatusCode.RequestTimeout;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
            }
            else if (exception is ServiceUnavailableException)
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "Service is Unavaliable.");
                result.Result = null;
                result.StatusCode = HttpStatusCode.ServiceUnavailable;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
            }
            else if (exception is UnauthorizedException)
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "Unauthorized Request");
                result.Result = null;
                result.StatusCode = HttpStatusCode.Unauthorized;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (exception is CanNotBeDeletedException)
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "This data can not be deleted.");
                result.Result = null;
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                result.ErrorMessage = exception.StackTrace;
                result.UserErrorMessage = (exception.Message ?? "Unknown exception.Please contact server adminastirator.");
                result.Result = null;
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Success = false;

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            #endregion            

            Log.Error(exception, exception.Message);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result), Encoding.UTF8);
        }
    }
}
