namespace Gateway.ClientAI.Models.QuestionGeneration
{
    public class TextAssessmebtDetails
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string AssessmentLink { get; set; } = default!;
    }
}
