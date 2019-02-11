using Microsoft.AspNetCore.Builder;

namespace IfCompanyTask.API.Middlewares
{
    /// <summary>
    /// The Global Exception Extensions
    /// </summary>
    public static class GlobalExceptionExtensions
    {
        /// <summary>
        /// Uses the global exception middleware.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
