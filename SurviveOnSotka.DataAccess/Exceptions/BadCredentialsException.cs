using System.Net;

namespace SurviveOnSotka.DataAccess.Exceptions
{
    public class BadCredentialsException : BaseCrudException
    {
        public BadCredentialsException(string message) : base(message) =>
            StatusCode = HttpStatusCode.BadRequest;

    }
}
