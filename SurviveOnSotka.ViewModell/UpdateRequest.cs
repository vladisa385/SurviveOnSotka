using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModell
{
    public abstract class UpdateRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
