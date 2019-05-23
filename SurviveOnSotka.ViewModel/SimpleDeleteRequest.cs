using SurviveOnSotka.ViewModell.Requests;
using System;

namespace SurviveOnSotka.ViewModel.Implementanion
{
    public class SimpleDeleteRequest : Request
    {
        public Guid Id { get; set; }
    }
}