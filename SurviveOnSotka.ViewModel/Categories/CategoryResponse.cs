using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Categories
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
        [MinLength(16), MaxLength(64)]
        public string Descriptrion { get; set; }
        public Guid ParentCategory { get; set; }
        public IFormFile Icon { get; set; }
        public int RecipiesCount { get; set; }
    }
}
