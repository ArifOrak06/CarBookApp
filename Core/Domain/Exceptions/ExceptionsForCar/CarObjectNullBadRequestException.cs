namespace Domain.Exceptions.ExceptionsForCar
{
    public sealed class CarObjectNullBadRequestException : BadRequestException
    {
        public CarObjectNullBadRequestException() : base($"Parametre olarak gönderilen obje null!")
        {
        }
    }
}
