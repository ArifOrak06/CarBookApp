namespace Domain.Entities
{
    public class Banner
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public string? Description { get; set; }
        public string? VideoDescription { get; set; }
        public string? VideoUrl { get; set; }

    }
}
