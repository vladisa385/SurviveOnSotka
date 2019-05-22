using System;
namespace SurviveOnSotka.ViewModell.Requests
{
    public class Request
    {
        private Guid _userId;

        public void SetUserId(Guid id) => _userId = id;

        public Guid GetUserId() => _userId;

        public bool IsLegalAccess(Guid? userId)
        {
            return _userId == userId;
        }
    }
}
