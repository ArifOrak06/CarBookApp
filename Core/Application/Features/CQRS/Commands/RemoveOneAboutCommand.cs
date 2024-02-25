namespace Application.Features.CQRS.Commands
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
