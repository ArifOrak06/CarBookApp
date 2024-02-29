namespace Application.Features.CQRS.Results.CarResults
{
    public class CreateOneCarCommandResult
    {
        public int Id { get; set; }
        public int Km { get; set; }
        public string Model { get; set; }
    }
}
