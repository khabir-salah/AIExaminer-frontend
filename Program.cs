using AI.Client.GateWay.Services;
using Blazored.Toast;
using Gateway.ClientAI.Services.Authentication;
using Gateway.ClientAI.Services.QuestionGeneration;
using Gateway.Services.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using static Gateway.ClientAI.Models.QuestionGeneration.GenerateTextViewModel;
using static Gateway.ClientAI.Models.QuestionGeneration.ResultModel;

namespace AI.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);


            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7063")
            });


            builder.Services.AddScoped(async sp =>
            {
                var httpClient = await Task.Run(async () => await Auth.CreateHttpClientAsync(sp));
                return httpClient;
            });

            builder.Services.AddScoped<ToastService>();


            builder.Services.AddBootstrapBlazor();
            builder.Services.AddOptions();
            builder.Services.AddBlazorBootstrap();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthentication, Authentication>();
            builder.Services.AddScoped<IAssessment, Assessment>();
            builder.Services.AddScoped<AssessmentService>();
            builder.Services.AddScoped<ResultViewModel>();

            

            //builder.Services.AddScoped(sp =>
            //{
            //    var client = new HttpClient
            //    {
            //        BaseAddress = new Uri("https://localhost:7063"),
            //        Timeout = TimeSpan.FromMinutes(30)
            //    };

            //    // DelegatingHandler or middleware to add the token
            //    var token = sp.GetRequiredService<IJSRuntime>()
            //                   .InvokeAsync<string>("sessionStorage.getItem", "authToken")
            //                   .GetAwaiter().GetResult();

            //    if (!string.IsNullOrEmpty(token))
            //    {
            //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //    }

            //    return client;
            //});

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            await builder.Build().RunAsync();



        }
    }
}
