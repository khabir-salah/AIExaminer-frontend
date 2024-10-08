using Gateway.Client.Models.Authentication;
using Gateway.Models.Authentication;
using Gateway.Services.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Gateway.ClientAI.Services.Authentication
{
    public class CustomAuthenticationStateProvider(IAuthentication _api, HttpClient _httpClient, IJSRuntime _jsRuntime) : AuthenticationStateProvider
    {
        private CurrentUser _currentUser;

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var token = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var userInfo = await GetCurrentUser();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, _currentUser.UserName) }.Concat(_currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");

                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public void NotifyUserAuthentication(ClaimsPrincipal user)
        {
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var identity = new ClaimsIdentity();
            var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
            NotifyAuthenticationStateChanged(authState);
        }

        private async Task<CurrentUser> GetCurrentUser()
        {
            if (_currentUser != null && _currentUser.IsAuthenticated) return _currentUser;
            _currentUser = await _api.CurrentUserInfo();
            return _currentUser;
        }

        public async Task Login(LoginRequestModel loginParameters)
        {
            await _api.Login(loginParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public async Task Register(ViewRegisterModel registerParameters)
        {
            await _api.Register(registerParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }

    public static class Auth
    {
        public static async Task<HttpClient> CreateHttpClientAsync(IServiceProvider sp)
        {
            var token = await sp.GetRequiredService<IJSRuntime>()
                                .InvokeAsync<string>("sessionStorage.getItem", "authToken");

            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7063"),
                Timeout = TimeSpan.FromMinutes(30)
            };

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }
    }
}
