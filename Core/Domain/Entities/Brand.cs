namespace Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Car> Cars { get; set; } = new();
    }
}
