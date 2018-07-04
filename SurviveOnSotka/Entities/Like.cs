using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurviveOnSotka.Entities
{
    public class Like
    {
        [Key]
        public Recipe Recipe { get; set; }
        [Key]
        public User UserWhoGiveLike { get; set; }
    }
}
