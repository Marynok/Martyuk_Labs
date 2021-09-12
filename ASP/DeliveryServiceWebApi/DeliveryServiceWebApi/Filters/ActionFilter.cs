using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DeliveryServiceWebApi.Filters
{
    public class ActionFilter :Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext rContext = null;
            string stringContent = string.Empty;

            try
            {
                context.HttpContext.Request.EnableBuffering();
                context.HttpContext.Request.Body.Position = 0;

                using (var reader = new StreamReader(context.HttpContext.Request.Body))
                {
                    stringContent = await reader.ReadToEndAsync();

                    context.HttpContext.Request.Body.Position = 0;
                }

                rContext = await next();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            Console.WriteLine(stringContent);
        }
    }
}
