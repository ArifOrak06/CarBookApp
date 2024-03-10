namespace Application.Features.CQRS.Results.ProvidedServiceResults
{
    public class UpdateOneProvidedServiceCommandResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
