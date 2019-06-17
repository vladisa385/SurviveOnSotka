using System.Net;

namespace SurviveOnSotka.DataAccess.Exceptions
{
    public class DeleteItemException : BaseCrudException
    {
        public DeleteItemException(string message) : base(message)
            => StatusCode = HttpStatusCode.BadRequest;
    }
}