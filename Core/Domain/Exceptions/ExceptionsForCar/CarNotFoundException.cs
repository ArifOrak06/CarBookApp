namespace Domain.Exceptions.ExceptionsForCar
{
    public sealed class CarNotFoundException : NotFoundException
    {
        public CarNotFoundException(int id) : base($"Car with Id : {id} could'nt found.")
        {
        }
    }
}
