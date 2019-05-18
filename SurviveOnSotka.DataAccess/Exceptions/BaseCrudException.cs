using System;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace SurviveOnSotka.DataAccess.Exceptions
{
    public class BaseCrudException:Exception
    {
        public DbUpdateException DbUpdateException { get; set; }
        public HttpStatusCode StatusCode { get; }
        public BaseCrudException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
