namespace Gateway.ClientAI.Models.QuestionGeneration
{

    public record class TetakeAssessmentViewModel
    {
        public Guid AssessmentId { get; set; }

        public ICollection<QuestionModel> Question { get; set; }

    }

    public record class QuestionModel
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public ICollection<OptionModel> Options { get; set; }
    }

    public record class OptionModel
    {
        public Guid OptionId { get; set; }
        public string Text { get; set; }
    }
}
