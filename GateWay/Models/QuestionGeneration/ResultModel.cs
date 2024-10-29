using static Gateway.ClientAI.Models.QuestionGeneration.SubmitAssessmentModel;

namespace Gateway.ClientAI.Models.QuestionGeneration
{
    public class ResultModel
    {
        public class ResultViewModel
        {
            public AssessmentResultResponseModel AssessmentResult { get; set; } = default!;
        }
    }
}
