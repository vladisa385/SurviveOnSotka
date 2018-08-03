using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.TypeFoods
{
    public class CreateTypeFoodRequest
    {
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
    }
}
