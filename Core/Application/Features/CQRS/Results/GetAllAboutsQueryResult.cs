﻿namespace Application.Features.CQRS.Results
{
    public class GetAllAboutsQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
