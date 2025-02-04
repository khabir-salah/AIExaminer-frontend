﻿
using AI.Client.GateWay.Models.Authentication;
using Gateway.ClientAI.Models.QuestionGeneration;
using static Gateway.ClientAI.Models.QuestionGeneration.GenerateTextViewModel;
using static Gateway.ClientAI.Models.QuestionGeneration.QuestionViewModel;
using static Gateway.ClientAI.Models.QuestionGeneration.SubmitAssessmentModel;

namespace Gateway.ClientAI.Services.QuestionGeneration
{
    public interface IAssessment
    {
        Task<AssessmentResponse?> TextGeneratedQuestion(TextModel request);
        Task<AssessmentResultResponseModel?> Submit(SubmitAssessmentRequest request);
        Task<ICollection<TextAssessmebtDetails?>> TextAssessmentDetails();
        Task<TetakeAssessmentViewModel?> RetakeAssessment(Guid AssessmentId);
        Task<PaystackResponse?> Subscribe(string planType);
        Task<TetakeAssessmentViewModel?> TakeAssessment(Guid AssessmentId);
        Task<AssessmentResultResponseModel?> SubmitResult(SubmitAssessmentRequest request);
    }
}
