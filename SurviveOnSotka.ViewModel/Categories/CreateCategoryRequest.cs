using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.ViewModel.Implementanion.Categories
{
    public class CreateCategoryRequest:Request
    {
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        [MinLength(10), MaxLength(64)]
        public string Descriptrion { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public IFormFile Icon { get; set; }

    }
}
