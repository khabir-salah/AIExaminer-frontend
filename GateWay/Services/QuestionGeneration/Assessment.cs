

using Gateway.ClientAI.Models.QuestionGeneration;
using System.Net.Http.Json;
using System.Text.Json;
using static Gateway.ClientAI.Models.QuestionGeneration.GenerateTextViewModel;
using static Gateway.ClientAI.Models.QuestionGeneration.QuestionViewModel;
using static Gateway.ClientAI.Models.QuestionGeneration.SubmitAssessmentModel;

namespace Gateway.ClientAI.Services.QuestionGeneration
{
    public class Assessment(HttpClient _client) : IAssessment
    {
        public async Task<AssessmentResponse?> TextGeneratedQuestion(TextModel request)
        {
            var loader = await _client.PostAsJsonAsync(UrlRoute.Generate, request);
            if (loader.IsSuccessStatusCode)
            {
                var responseContent = await loader.Content.ReadAsStringAsync();

                var assessment = JsonSerializer.Deserialize<AssessmentResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true 
                });

                return assessment;
            }
            else
            {
                throw new Exception($"Error occurred while generating questions: {loader.StatusCode}");
            }
        }

        public async Task<AssessmentResultResponseModel?> Submit(SubmitAssessmentRequest request)
        {
            var loader = await _client.PostAsJsonAsync(UrlRoute.Result, request);
            if (loader.IsSuccessStatusCode)
            {
                var responseContent = await loader.Content.ReadAsStringAsync();

                var assessment = JsonSerializer.Deserialize<AssessmentResultResponseModel>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return assessment;
            }
            else
            {
                throw new Exception($"Error occurred while generating questions: {loader.StatusCode}");
            }
        }

        public async Task<ICollection<TextAssessmebtDetails?>> TextAssessmentDetails()
        {
            var loader = await _client.GetAsync(UrlRoute.TextDetails);
            if(loader.IsSuccessStatusCode)
            {
                var data = await loader.Content.ReadFromJsonAsync<List<TextAssessmebtDetails>>();
                return data;
            }
            else
            {
                throw new Exception($"An Error occurred: {loader.StatusCode}");
            }
        }

        public async Task<TetakeAssessmentViewModel?> RetakeAssessment( Guid AssessmentId)
        {
            var urlWithParams = $"{UrlRoute.RetakeAssessment}?assessmentId={AssessmentId}";
            var loader = await _client.GetAsync(urlWithParams);

            if (loader.IsSuccessStatusCode)
            {
                var data = await loader.Content.ReadFromJsonAsync<TetakeAssessmentViewModel>();
                return data;
            }
            else
            {
                throw new Exception($"An Error occurred: {loader.StatusCode}");
            }
        }
    }
}
