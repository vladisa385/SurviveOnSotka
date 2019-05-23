using SurviveOnSotka.ViewModell;
using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.Tags
{
    public class TagResponse : Response
    {
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public int RecipiesCount { get; set; }
    }
}