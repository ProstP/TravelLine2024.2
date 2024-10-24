using Domain.Entity;

namespace WebApi.Contract.Response
{
    public class LoginUserResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
