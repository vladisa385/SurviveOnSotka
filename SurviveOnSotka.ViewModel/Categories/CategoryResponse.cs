using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Categories
{
    public class CategoryResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        [MinLength(16), MaxLength(64)]
        public string Descriptrion { get; set; }
        public Guid? ParentCategory { get; set; }
        public string PathToIcon { get; set; }
        [Required]
        public int RecipiesCount { get; set; }
    }
}
