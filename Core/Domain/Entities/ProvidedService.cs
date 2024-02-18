namespace Domain.Entities
{
    public class ProvidedService
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? IconUrl { get; set; } 

    }
}
