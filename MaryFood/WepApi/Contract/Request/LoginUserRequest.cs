namespace WebApi.Contract.Request
{
    public class LoginUserRequest
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
