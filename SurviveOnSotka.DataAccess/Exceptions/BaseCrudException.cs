using System;
using System.Net;

namespace SurviveOnSotka.DataAccess.Exceptions
{
    public class BaseCrudException : Exception
    {
        public HttpStatusCode StatusCode { get; protected set; }

        public BaseCrudException(string message) : base(message)
        {
        }

        public BaseCrudException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}