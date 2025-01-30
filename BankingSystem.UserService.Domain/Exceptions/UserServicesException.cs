namespace BankingSystem.UserService.Domain.Exceptions
{
    public class UserServicesException : Exception
    {
        public UserServicesException() { }

        public UserServicesException(string message) : base(message) { }

        public UserServicesException(string message, Exception innerException) : base(message, innerException) { }
    }
}
