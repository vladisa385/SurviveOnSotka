using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurviveOnSotka.ViewModel.Cities
{
    public class CreateCityRequest
    {
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }

    }
}
