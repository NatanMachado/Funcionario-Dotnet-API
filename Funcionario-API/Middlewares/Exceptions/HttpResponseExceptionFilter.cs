using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace FuncionarioApi.Middlewares.Exceptions
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                var JsonContentTypes = new MediaTypeCollection();
                JsonContentTypes.Add(new MediaTypeHeaderValue("application/json"));
                FormatterCollection<IOutputFormatter> formatter = new FormatterCollection<IOutputFormatter>();
                                context.Result = new ObjectResult(httpResponseException.Value)
                {
                    StatusCode = httpResponseException.StatusCode,
                    Value = httpResponseException.Value,
                    ContentTypes = JsonContentTypes
                };

                context.ExceptionHandled = true;
            }
        }
    }
}