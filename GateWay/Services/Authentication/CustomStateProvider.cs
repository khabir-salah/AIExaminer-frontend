using Gateway.Client.Models.Authentication;
using Gateway.Models.Authentication;
using Gateway.Services.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;


namespace Gateway.Client.Services.Authentication
{
    public class CustomStateProvider(IAuthentication _api) : AuthenticationStateProvider
    {
        private CurrentUser _user;
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await GetCurrentUser();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, _user.UserName) }.Concat(_user.Claims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private async Task<CurrentUser> GetCurrentUser()
        {
            if (_user != null && _user.IsAuthenticated) return _user;
            _user = await _api.CurrentUserInfo();
            return _user;
        }

        public async Task Register(ViewRegisterModel registerParameters)
        {
            await _api.Register(registerParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
