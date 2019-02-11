using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.API.Middlewares
{
    /// <summary>
    /// The ResponseMetadataMiddleware
    /// </summary>
    public class ResponseMetadataMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate _next;
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseMetadataMiddleware" /> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <exception cref="ArgumentNullException">next
        /// or
        /// logger</exception>
        public ResponseMetadataMiddleware(RequestDelegate next)
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

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    context.Response.Body = memoryStream;

                    await _next.Invoke(context);

                    context.Response.Body = responseBody;

                    memoryStream.Seek(0, SeekOrigin.Begin);

                    var deserializeMemoryStream = JsonConvert.DeserializeObject(new StreamReader(memoryStream).ReadToEnd());
                    if (deserializeMemoryStream != null)
                    {
                        string result = JsonConvert.SerializeObject(ResponseMetadataModel.Create((HttpStatusCode)context.Response.StatusCode, deserializeMemoryStream, null));
                        await context.Response.WriteAsync(result, Encoding.UTF8);
                    }
                }
            }

        }
    }
}
