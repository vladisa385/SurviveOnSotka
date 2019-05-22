using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.ViewModel.Implementanion.Tags
{
    public class TagFilter:Filter
    {
        public string Name { get; set; }
        public RangeFilter<int> RecepiesCount { get; set; }
    }
}
