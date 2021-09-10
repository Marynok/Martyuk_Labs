using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DeliveryServiceWebApi.Filters
{
    public class ActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Console.WriteLine(filterContext.HttpContext.Request.Path.ToString());
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Console.WriteLine(filterContext.HttpContext.Request.Body);
        }
    }
}
