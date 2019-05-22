using System;
namespace SurviveOnSotka.ViewModell.Requests
{
    public class Request
    {
        public Guid UserId { get; private set; }

        public void SetUserId(Guid id) => UserId = id;

        public bool IsLegalAccess(Guid? userId)
        {
            return UserId == userId;
        }
    }
}
