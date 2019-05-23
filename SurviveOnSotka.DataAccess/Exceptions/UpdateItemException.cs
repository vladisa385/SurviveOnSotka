using System;
using System.Net;

namespace SurviveOnSotka.DataAccess.Exceptions
{
    public class UpdateItemException : BaseCrudException
    {
        public UpdateItemException(string message) : base(message) => StatusCode = HttpStatusCode.NotFound;

        public UpdateItemException(string message, Exception innerException) : base(message, innerException) => StatusCode = HttpStatusCode.NotFound;
    }
}