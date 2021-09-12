using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceWebApi.Filters
{
    public class FoodExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _env;

        public FoodExceptionFilter(ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            _logger = loggerFactory.CreateLogger("FoodExceptionFilter");
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
            if (_env.IsDevelopment())
            {
                _logger.LogInformation(context.Exception.Message);
                _logger.LogInformation(context.Exception.InnerException?.Message);
            }
            else
            if(_env.IsEnvironment("QA"))
            {
                _logger.LogInformation(context.Exception.Message);
                _logger.LogInformation(context.Exception.InnerException?.Message);
                _logger.LogInformation(context.Exception.StackTrace);
            }
            else
            if (_env.IsProduction())
            {
                _logger.LogInformation(context.Exception.Message);
            }

            context.ExceptionHandled = true;
        }
    }
}
