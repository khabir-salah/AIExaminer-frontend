using Gateway.Client.Models.Authentication;
using Gateway.Models.Authentication;
using static Gateway.ClientAI.Models.Authentication.ResetModel;


namespace Gateway.Services.Authentication
{
    public interface IAuthentication
    {
        Task Register(ViewRegisterModel registerRequest);
        Task Login(LoginRequestModel loginRequest);
        Task ResetPassword(ResetPasswordRequest request);
        Task ForgotPassword(ForgotPasswordRequest request);
        Task LogOut();
        Task Google();
        Task ConfirmEmail(ViewRegisterModel registerRequest);
        Task<CurrentUser> CurrentUserInfo();
    }
}
