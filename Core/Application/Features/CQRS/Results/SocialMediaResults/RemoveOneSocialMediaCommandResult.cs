namespace Application.Features.CQRS.Results.SocialMediaResults
{
    public class RemoveOneSocialMediaCommandResult
    {
        public int Id { get; set; }
        public RemoveOneSocialMediaCommandResult(int id)
        {
            Id = id;
        }
    }
}
