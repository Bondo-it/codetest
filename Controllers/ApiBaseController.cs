
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace codetest.Controllers
{
    public class ApiBaseController : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

            if (context.ExceptionHandled)
            {
                return;
            }

            var exception = context.Exception;
            var message = string.Format(exception.Message);
            if (exception is ArgumentException)
            {
                context.Result = new BadRequestObjectResult(message);
            }
            else if (exception is UnauthorizedAccessException)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                context.Result = new BadRequestResult();
            }
            context.HttpContext.Response.Headers.Add("X-codetest-error", message);
            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}