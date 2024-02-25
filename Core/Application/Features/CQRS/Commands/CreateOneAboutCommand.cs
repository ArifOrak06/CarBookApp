namespace Application.Features.CQRS.Commands
{
    public class CreateOneAboutCommand
    {
        public string Title { get; set; } 
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
