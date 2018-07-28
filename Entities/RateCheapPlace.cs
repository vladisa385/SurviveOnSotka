using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurviveOnSotka.Entities
{
    public class RateCheapPlace
    {
        public Guid CheapPlaceId { get; set; }
        public string UserWhoGiveMarkId { get; set; }
        public CheapPlace Review { get; set; }
        public User UserWhoGiveMark { get; set; }
        [Required]
        public bool IsCool { get; set; }

        public ICollection<RateCheapPlace> RateCheapPlaces { get; set; }
    }
}
