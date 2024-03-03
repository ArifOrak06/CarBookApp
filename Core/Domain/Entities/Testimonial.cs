using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class Testimonial : BaseEntity, IEntity
    {
        public string Name { get; set; } 
        public string Title { get; set; } 
        public string Comment { get; set; } 
        public string ImageUrl { get; set; }
    }
}
