using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurviveOnSotka.Entities
{
    public class Like
    {

        public int IdRecipe { get; set; }
        public int IdUserWhoGiveLike { get; set; }
    }
}
