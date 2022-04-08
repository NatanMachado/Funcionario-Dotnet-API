using System.Net;
using FuncionarioApi.Middlewares.Exceptions;
using Newtonsoft.Json;

namespace Funcionario_API.Middlewares.Exceptions
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (FailValidationException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, FailValidationException exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is Exception) code = HttpStatusCode.NotFound;

            var result = JsonConvert.SerializeObject(new { status = exception.StatusCode, message = (string) exception.Value });
            return WriteResponse(context, code, result);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is Exception) code = HttpStatusCode.NotFound;

            var result = JsonConvert.SerializeObject(new { status = code, error = exception.Message });
            return WriteResponse(context, code, result);
        }

        private static Task WriteResponse(HttpContext context, HttpStatusCode code, string result)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}