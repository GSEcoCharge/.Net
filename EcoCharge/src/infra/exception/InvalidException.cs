namespace EcoCharge.infra.exception
{
    public class InvalidException : Exception
    {
        public InvalidException(string message) : base(message) { }
    }
}