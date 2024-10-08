using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gateway.ClientAI.Models.QuestionGeneration.GenerateTextViewModel;

namespace Gateway.ClientAI.Models.QuestionGeneration
{
    public class SubmitAssessmentModel
    {
        public class SubmitAssessmentRequest
        {
            public Dictionary<Guid, string> Answer { get; set; } 
            public Guid AssesmentId { get; set; }
        }

        public record class QuestionResponseView
        {
            public string QuestionText { get; set; }
            public ICollection<OptionResponseView> Options { get; set; }
            public string Answer { get; set; }
            public string Explanation { get; set; }
            public string UserAnswer { get; set; }
        }

        public record class OptionResponseView
        {
            public string Text { get; set; }
        }

        public record class AssessmentResultResponseModel
        {
            public Guid AssesmentId { get; set; }
            public double Score { get; set; }
            public ICollection<QuestionResponseView> Questions { get; set; }
        }

        public record class AssessmentResponseView
        {
            public ICollection<QuestionResponseView> Question { get; set; }
            public QuestionType QuestionType { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
