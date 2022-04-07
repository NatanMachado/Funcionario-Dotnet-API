using System.Net;

namespace FuncionarioApi.Middlewares.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int statusCode, object? value = null) =>
        (StatusCode, Value) = (statusCode, value);

        public int StatusCode { get; }

        public object? Value { get; }
    }
}