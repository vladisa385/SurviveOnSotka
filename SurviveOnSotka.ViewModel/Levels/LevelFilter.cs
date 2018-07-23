using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.ViewModel.Levels
{
    public class LevelFilter
    {
        public RangeFilter<int> MinScore { get; set; }
        public RangeFilter<int> MaxScore { get; set; }
        public RangeFilter<int> Users { get; set; }
        public Guid? NextLevelId { get; set; }
        public Guid? LastLevelId { get; set; }
        public Guid? Id { get; set; }
        public string Name { get; set; }

    }
}
