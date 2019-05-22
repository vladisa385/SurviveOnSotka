using System;
using System.Net;

namespace SurviveOnSotka.DataAccess.Exceptions
{
    public class CreateItemException:BaseCrudException
    {
        public CreateItemException(string message, Exception innerException) : base(message, innerException) => StatusCode = HttpStatusCode.BadRequest;

        public CreateItemException(string message) : base(message) => StatusCode = HttpStatusCode.BadRequest;
    }
}
