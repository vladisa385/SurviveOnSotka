using System.Net;

namespace SurviveOnSotka.DataAccess.Exceptions
{
    public class UpdateItemException:BaseCrudException
    {
        public UpdateItemException(string message) : base(message, HttpStatusCode.NotFound)
        {}
    }
}
