namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class RemoveOneAboutCommand
    {
        public int Id { get; set; }
        public RemoveOneAboutCommand(int id)
        {
            Id = id;
        }
    }
}
