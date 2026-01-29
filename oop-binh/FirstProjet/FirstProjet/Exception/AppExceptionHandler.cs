using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace FirstProjet.Exception
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
        {
            var exceptionResponse = new ExceptionResponse()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = exception.Message,
                ExceptionDateTime = DateTime.UtcNow
            };

            var jsonResponse = JsonSerializer.Serialize(exceptionResponse);
            httpContext.Response.StatusCode = exceptionResponse.StatusCode;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(jsonResponse);

            return true;
        }
    }
}
