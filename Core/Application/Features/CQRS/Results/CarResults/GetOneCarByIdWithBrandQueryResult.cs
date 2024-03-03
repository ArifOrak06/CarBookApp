namespace Application.Features.CQRS.Results.CarResults
{
    public class GetOneCarByIdWithBrandQueryResult
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public int Luggage { get; set; }
        public int Seat { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
