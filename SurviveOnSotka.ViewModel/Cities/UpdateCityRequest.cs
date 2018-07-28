using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurviveOnSotka.ViewModel.Cities
{
    public class UpdateCityRequest
    {
        [Required, MinLength(5)]
        public string Name { get; set; }

    }
}
