namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateOneCategoryCommand
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
