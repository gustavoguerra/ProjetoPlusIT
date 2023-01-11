using Newtonsoft.Json;
using Sorvete.Domain.Helpers;
using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace Sorvete.Application.Extensions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        protected readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var message = string.Empty;
                var localErro = string.Empty;

                var sTackTrace = new StackTrace(error);
                var thisasm = Assembly.GetExecutingAssembly();
                var methodName = sTackTrace.GetFrames().Select(f => f.GetMethod()).First(m => m.Module.Assembly == thisasm).ToString();

                switch (error)
                {
                    case DomainException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = error.Message;
                        localErro = "DomainException: " + methodName;
                        break;
                    case ArgumentException:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = Messages.ERROR_TOKEN;
                        localErro = "Token Security: " + methodName;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        message = Messages.ERROR_GENERIC;
                        localErro = "Metodo: " + methodName;
                        break;
                }
                _logger.LogError(error, error.Message);
                var result = JsonConvert.SerializeObject(new { message = message });
                await response.WriteAsync(result);
            }
        }
    }
}
