using Gateway.Client.Models.Authentication;
using Gateway.Models.Authentication;


namespace Gateway.Services.Authentication
{
    public interface IAuthentication
    {
        Task Register(ViewRegisterModel registerRequest);
        Task<CurrentUser> CurrentUserInfo();
    }
}
