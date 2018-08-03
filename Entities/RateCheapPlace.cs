using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class RateCheapPlace
    {
        public Guid CheapPlaceId { get; set; }
        public string UserWhoGiveMarkId { get; set; }
        public CheapPlace CheapPlace { get; set; }
        public User UserWhoGiveMark { get; set; }
        [Required]
        public bool IsCool { get; set; }

    }
}
