namespace EcoCharge.infra.exception
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}