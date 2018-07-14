using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.Categories
{
    public class CreateCategoryRequest
    {
        [Required, MinLength(5), MaxLength(16)]
        public string Name { get; set; }
        [MinLength(16), MaxLength(64)]
        public string Descriptrion { get; set; }
        public Guid IdParentCategory { get; set; }
        public IFormFile Icon { get; set; }

    }
}
