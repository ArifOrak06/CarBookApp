using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class CarDescription : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } 
        public string Description { get; set; } 
    }
}
