using System.Net.Mail;
using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is JourneyException)
            {
                var JourneyException = (JourneyException) context.Exception;

                context.HttpContext.Response.StatusCode = (int)JourneyException.GetStatusCode();
                var responseJson = new ResponseErrosJson(JourneyException.GetErrorMessage());
                context.Result = new ObjectResult(responseJson); 
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var list = new List<string>{"Erro desconhecido"};
                var responseJson = new ResponseErrosJson(list);
                context.Result = new ObjectResult(responseJson); 
            }
        }
    }
}