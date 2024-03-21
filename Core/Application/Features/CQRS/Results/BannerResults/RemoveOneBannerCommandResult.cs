namespace Application.Features.CQRS.Results.BannerResults
{
    public class RemoveOneBannerCommandResult
    {
        public int Id { get; set; }

        public RemoveOneBannerCommandResult(int id)
        {
            Id = id;
        }
    }
}
