using System.Data.Common;
using System.Net;
using System.Text.Json;
using UOB.Shared.Common;

namespace UOB.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var response = new ApiResponse<string>
            {
                Success = false,
                Message = "An error occurred.",
                Data = null
            };

            var statusCode = HttpStatusCode.InternalServerError;

            // Handle different exception types
            switch (ex)
            {
                case ArgumentNullException:
                    statusCode = HttpStatusCode.BadRequest;
                    response.Message = $"Missing argument: {ex.Message}";
                    break;

                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;
                    response.Message = ex.Message;
                    break;

                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    response.Message = ex.Message;
                    break;

                case DbException:
                    statusCode = HttpStatusCode.InternalServerError;
                    response.Message = "Database error occurred.";
                    break;

                case InvalidOperationException:
                    statusCode = HttpStatusCode.Conflict;
                    response.Message = ex.Message;
                    break;

                case DivideByZeroException:
                    statusCode = HttpStatusCode.BadRequest;
                    response.Message = "Division by zero occurred.";
                    break;

                default:
                    response.Message = ex.Message;
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(result);
        }
    }
}
