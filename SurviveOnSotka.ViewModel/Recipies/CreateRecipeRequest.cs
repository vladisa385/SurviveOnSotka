using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.Recipies
{
    public class CreateRecipeRequest
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
