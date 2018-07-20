using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.TypeFoods
{
    public class UpdateTypeFoodRequest
    {
        [Required, MinLength(5), MaxLength(16)]
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
    }
}
