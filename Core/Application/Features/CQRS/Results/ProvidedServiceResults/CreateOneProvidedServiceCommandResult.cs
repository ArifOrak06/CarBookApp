namespace Application.Features.CQRS.Results.ProvidedServiceResults
{
    public class CreateOneProvidedServiceCommandResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
