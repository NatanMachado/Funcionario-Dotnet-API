using System.Net;

namespace FuncionarioApi.Middlewares.Exceptions
{
    public class FailValidationException : Exception
    {
        public FailValidationException(HttpStatusCode status, string message) =>
        (StatusCode, Value) = (status, message);

        public HttpStatusCode StatusCode { get; }

        public object? Value { get; }
    }
}