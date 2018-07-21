﻿namespace SurviveOnSotka.Entities
{
    public class Step : DomainObject
    {
        public Step NextStep { get; set; }
        public string Description { get; set; }
        public string PathToPhoto { get; set; }
    }
}