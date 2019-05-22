using System;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.ViewModel.Implementanion
{
    public class SimpleDeleteRequest:Request
    {
        public Guid Id { get; set; }
    }
}
