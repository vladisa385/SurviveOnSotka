using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Recipies
{
    public class UpdateRecipeRequest
    {
        [Required, MinLength(5)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string PathToPhotos { get; set; }
        public DateTime TimeForCooking { get; set; }
        public DateTime TimeForPreparetion { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
    }
}
