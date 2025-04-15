namespace Application.UseCases.Categories.ManageCategory
{
    public class ManageCategoryInput
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
