namespace WebApi.Contract.Request
{
    public class RegisterUserRequest
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
