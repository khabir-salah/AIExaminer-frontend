using Gateway.Client.Models.Authentication;
using Gateway.Models.Authentication;
using System.Net.Http.Json;


namespace Gateway.Services.Authentication
{
    public class Authentication(HttpClient _httpClient) : IAuthentication
    {
        public async Task Register(ViewRegisterModel registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/account/register", registerRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task<CurrentUser> CurrentUserInfo()
        {
            var result = await _httpClient.GetFromJsonAsync<CurrentUser>("api/authentication/currentuserinfo") ??
            throw new ArgumentNullException("user not found");
            return result;
        }
    }
}
