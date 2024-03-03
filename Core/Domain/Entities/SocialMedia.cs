using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class SocialMedia : BaseEntity, IEntity
    {
        public string Name { get; set; } 
        public string Url { get; set; } 
        public string Icon { get; set; } 
    }
}
