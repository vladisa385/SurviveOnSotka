﻿using System;

namespace SurviveOnSotka.Entities
{
    public class TagsInCheapPlaces
    {
        public CheapPlace CheapPlace { get; set; }
        public Guid CheapPlaceId { get; set; }
        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}