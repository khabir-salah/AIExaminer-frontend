using AI.Client.GateWay.Services.Authentication;
using Gateway.Client.Models.Authentication;
using Gateway.Models.Authentication;
using System.Net.Http;
using System.Net.Http.Json;
using static Gateway.ClientAI.Models.Authentication.ResetModel;


namespace Gateway.Services.Authentication
{
    public class Authentication(HttpClient _httpClient) : IAuthentication
    {
        public async Task Register(ViewRegisterModel registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync(Route.Register, registerRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task Login(LoginRequestModel loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync(Route.Login, loginRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task LogOut()
        {
            
        }

        public async Task ConfirmEmail(ViewRegisterModel registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync(Route.ConfirmEmail, registerRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }


        public async Task ResetPassword(ResetPasswordRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync(Route.ResetPassword, request);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task ForgotPassword(ForgotPasswordRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync(Route.ForgotPassword, request);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

    }
}
