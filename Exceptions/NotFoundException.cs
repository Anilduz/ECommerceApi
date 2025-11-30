namespace ECommerceApi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, int id)
            : base($"{entityName} ID'si {id} olan kayıt bulunamadı.")
        {
        }
    }
}
