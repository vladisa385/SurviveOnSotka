using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.DataAccess.CheapPlaces
{
    public class ThisRequestNotFromOwnerException : Exception
    {

        public ThisRequestNotFromOwnerException()
            : base("This request is not from owner.Access denied") { }

    }
}
