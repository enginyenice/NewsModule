using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Business.Exceptions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessException e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }


        private Task HandleExceptionAsync(HttpContext httpContext, BusinessException e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "OK";
            
            message = e.Message;
            httpContext.Response.StatusCode = e.StatusCode;

            return httpContext.Response.WriteAsync(new BusinessExceptionDetails { StatusCode = e.StatusCode, Message = message }.ToString());

        }
    }

}
