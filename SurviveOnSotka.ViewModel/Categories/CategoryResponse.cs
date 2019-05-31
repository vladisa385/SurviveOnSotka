using SurviveOnSotka.ViewModell;
using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.Categories
{
    public class CategoryResponse : Response
    {
        [Required]
        public Guid Id { get; set; }

        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }

        [MinLength(16), MaxLength(64)]
        public string Descriptrion { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public string Icon { get; set; }

        [Required]
        public int RecipiesCount { get; set; }

        [Required]
        public int CategoriesCount { get; set; }
    }
}