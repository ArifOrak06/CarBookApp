namespace Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveOneContactCommand
    {
        public int Id { get; set; }
        public RemoveOneContactCommand(int id)
        {
            Id = id;
        }
    }
}
