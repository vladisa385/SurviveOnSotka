using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SurviveOnSotka.DataAccess.Exceptions
{
    public class IllegalAccessException:BaseCrudException
    {
        public IllegalAccessException() : base("This action doesnt come from creator") => StatusCode = HttpStatusCode.Forbidden;
    }
}
