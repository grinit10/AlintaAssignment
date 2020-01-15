using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlintaAssignment.WebAPi.Extensions
{
    public class CustomLoggingExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public CustomLoggingExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("CustomLoggingExceptionFilter");
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogInformation(context.Exception.Message);
        }
    }
}
