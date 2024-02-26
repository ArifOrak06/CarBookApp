namespace Application.Features.CQRS.Commands.BannerCommands
{
    public class CreateOneBannerCommand
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? VideoDescription { get; set; }
        public string? VideoUrl { get; set; }
    }
}
