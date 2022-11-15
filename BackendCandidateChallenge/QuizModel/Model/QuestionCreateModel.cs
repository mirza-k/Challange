namespace QuizModel.Model;

public class QuestionCreateModel
{
    public QuestionCreateModel(string text, long quizId)
    {
        Text = text;
        QuizId = quizId;
    }

    public string Text { get; set; }
    public long QuizId { get; set; }
}