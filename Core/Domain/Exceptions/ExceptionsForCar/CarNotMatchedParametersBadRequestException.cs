namespace Domain.Exceptions.ExceptionsForCar
{
    public sealed class CarNotMatchedParametersBadRequestException : BadRequestException
    {
        public CarNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak gönderilen varlık Id : {id} ile object olarak gönderilen Id değerleri eşleşmemektedir.")
        {
        }
    }
}
