namespace Application.Features.CQRS.Commands.CarCommands
{
    public class RemoveOneCarCommand
    {
        public int Id { get; set; }
        public RemoveOneCarCommand(int id)
        {
            Id = id;
        }
    }
}
