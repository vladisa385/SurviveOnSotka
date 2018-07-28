namespace SurviveOnSotka.Entities
{
    public class Step : DomainObject
    {
        public Step NextStep { get; set; }
        public int NumberStep { get; set; }
        public string Description { get; set; }
        public string PathToPhoto { get; set; }
        public Recipe Recipe { get; set; }
        public Recipe RecipeId { get; set; }
    }
}
