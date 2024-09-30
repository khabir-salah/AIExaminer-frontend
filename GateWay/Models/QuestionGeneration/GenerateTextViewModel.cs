using System.ComponentModel.DataAnnotations;
using static Gateway.ClientAI.Models.QuestionGeneration.QuestionViewModel;

namespace Gateway.ClientAI.Models.QuestionGeneration
{
    public class GenerateTextViewModel
    {
        public class TextModel
        {
            [Required(ErrorMessage = "Title content is required.")]
            public string Title { get; set; }
            public string Content { get; set; }
            public Choice Choice { get; set; }
        }

        

        public enum QuestionType
        {
            MultipleChoice = 1,
            TrueOrFalse,
        }

       

        public class Choice
        {
            public int NumberOfQuestion { get; set; }
            public QuestionType Type { get; set; }
        }

        public class AssessmentService
        {
            public AssessmentResponse Assessment { get; set; }
        }
    }
}
