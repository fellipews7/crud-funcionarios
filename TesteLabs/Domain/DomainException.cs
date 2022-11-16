namespace TesteLabs.Domain
{
    public class DomainException : ApplicationException
    {
        public DomainException(string? message) : base(message)
        {
        }
    }
}
