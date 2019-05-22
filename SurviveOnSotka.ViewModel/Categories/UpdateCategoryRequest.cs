using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Categories
{
    public class UpdateCategoryRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        [MinLength(10), MaxLength(64)]
        public string Descriptrion { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public IFormFile Icon { get; set; }
    }
}
