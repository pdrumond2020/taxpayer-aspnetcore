using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Taxpayer.Application.Model.RequestResponse;

namespace Taxpayer.Web.Extensions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (HttpStatusCodeException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception exceptionObj)
            {
                await HandleExceptionAsync(context, exceptionObj);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusCodeException exception)
        {
            ErrorDetails result;
            context.Response.ContentType = "application/json";
            if (exception != null)
            {
                result = new ErrorDetails() { StatusCode = exception.StatusCode, Message = exception.Message };
                context.Response.StatusCode = (int)exception.StatusCode;
            }
            else
            {
                result = new ErrorDetails() { StatusCode = HttpStatusCode.BadRequest, Message = exception.Message };
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return context.Response.WriteAsync(result.ToString());
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var result = new ErrorDetails() { StatusCode = statusCode, Message = exception.Message };

            return context.Response.WriteAsync(result.ToString());
        }
    }
}