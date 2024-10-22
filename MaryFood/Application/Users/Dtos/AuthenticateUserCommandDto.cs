namespace Application.Users.Dtos
{
    public class AuthenticateUserCommandDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
