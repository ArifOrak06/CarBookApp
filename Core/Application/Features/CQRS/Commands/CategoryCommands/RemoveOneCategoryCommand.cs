namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveOneCategoryCommand
    {
        public int Id { get; set; }
        public RemoveOneCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
