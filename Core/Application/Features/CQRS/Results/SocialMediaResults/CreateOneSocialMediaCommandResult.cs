namespace Application.Features.CQRS.Results.SocialMediaResults
{
    public class CreateOneSocialMediaCommandResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}
