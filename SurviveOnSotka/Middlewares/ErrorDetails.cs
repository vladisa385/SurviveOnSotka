using Newtonsoft.Json;
using SurviveOnSotka.DataAccess.Exceptions;
using System;
using System.Net;

namespace SurviveOnSotka.Middlewares
{
    public class ErrorDetails
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;
        public string Message { get; }// = "Internal Server Error";

        public ErrorDetails(Exception exception)
        {
            Message = $"{exception.Message} \n innerException: {exception.InnerException?.Message}";
            if (!(exception is BaseCrudException baseCrudException)) return;
            StatusCode = baseCrudException.StatusCode;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}