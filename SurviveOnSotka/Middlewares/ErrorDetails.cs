using System;
using System.Net;
using Newtonsoft.Json;
using SurviveOnSotka.DataAccess.Exceptions;

namespace SurviveOnSotka.Middlewares
{
    public class ErrorDetails
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;
        public string Message { get; } = "Internal Server Error";
        public ErrorDetails(Exception exception)
        {
            if (!(exception is BaseCrudException baseCrudException)) return;
            Message = exception.Message;
            StatusCode = baseCrudException.StatusCode;
        }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}