using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.DataAccess.ViewModels
{
    public abstract class UpdateRequest
    {
        public Guid Id { get; set; }
    }
}
