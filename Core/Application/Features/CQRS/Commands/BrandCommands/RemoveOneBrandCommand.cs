namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class RemoveOneBrandCommand
    {
        public int Id { get; set; }
        public RemoveOneBrandCommand(int id)
        {
            Id= id; 
        }
    }
}
