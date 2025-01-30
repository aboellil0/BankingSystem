namespace BankingSystem.UserService.Domain.Exceptions
{
    internal class UserNotFoundException : UserServicesException
    {
        public string Identifier { get; set; }

        public UserNotFoundException(string identifier) : base($"User {identifier} is not found")
        {
            Identifier = identifier;
        }
        public UserNotFoundException(string message, string identifier) : base(message)
        {
            Identifier = identifier;
        }
        public UserNotFoundException(string message, string identifier, Exception exciption) : base(message, exciption)
        {
            Identifier = identifier;
        }
    }
}
