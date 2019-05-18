using System.Net;

namespace SurviveOnSotka.DataAccess.Exceptions
{
    public class CreateItemException:BaseCrudException
    {
        public CreateItemException(string message) : base(message, HttpStatusCode.BadRequest)
        {}
    }
}
