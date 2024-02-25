﻿namespace Application.Features.CQRS.Commands
{
    public class UpdateOneAboutCommand
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string ImageUrl { get; set; }
    }
}
