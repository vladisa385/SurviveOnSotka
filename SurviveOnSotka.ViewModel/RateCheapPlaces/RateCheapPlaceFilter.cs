﻿using System;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.RateCheapPlaces
{
    public class RateCheapPlaceFilter
    {
        public Guid? CheapPlaceId { get; set; }
        public bool? IsCool { get; set; }
        public string UserWhoGiveMarkId { get; set; }
    }
}