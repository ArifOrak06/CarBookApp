﻿using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class FooterAddress : BaseEntity, IEntity
    {
        public string Description { get; set; }
        public string Address { get; set; } 
        public string Phone { get; set; } 
        public string Email { get; set; } 
    }
}
