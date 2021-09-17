using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceWebApi.Filters
{
    public class FoodExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger _logger;

        public FoodExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("FoodExceptionFilter");
        }
        public void OnException(ExceptionContext context)
        {
             _logger.LogInformation(context.Exception.Message);
            context.ExceptionHandled = true;
        }
    }
}
