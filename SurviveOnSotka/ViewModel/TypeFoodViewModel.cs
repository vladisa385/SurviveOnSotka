using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel
{
    public class TypeFoodViewModel
    {
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
        [Required]
        public IFormFile Avatar { get; set; }
    }
}
