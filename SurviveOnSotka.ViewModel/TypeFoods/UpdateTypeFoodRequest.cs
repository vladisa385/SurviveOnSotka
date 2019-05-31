using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModell.Requests;
using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.TypeFoods
{
    public class UpdateTypeFoodRequest : Request
    {
        public Guid Id { get; set; }

        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }

        public string Icon { get; set; }
    }
}