using System.Net;

namespace SurviveOnSotka.DataAccess.Exceptions
{
    public class DeleteItemCrudException:BaseCrudException
    {
        public DeleteItemCrudException(string message) : base(message,HttpStatusCode.BadRequest)
        { }
    }
}
