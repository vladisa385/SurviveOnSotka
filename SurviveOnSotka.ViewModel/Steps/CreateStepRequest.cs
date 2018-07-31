using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Steps
{
    public class CreateStepRequest
    {
        public int NumberStep { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}
