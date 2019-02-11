using Microsoft.AspNetCore.Builder;

namespace IfCompanyTask.API.Middlewares
{
    /// <summary>
    /// The ResponseMetadataExtensions
    /// </summary>
    public static class ResponseMetadataExtensions
    {
        /// <summary>
        /// Uses the response metadata middleware.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseResponseMetadataMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseMetadataMiddleware>();
        }
    }
}
