namespace Application.UseCases.Categories.SearchCategory
{
    public class SearchCategoryOutput
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
