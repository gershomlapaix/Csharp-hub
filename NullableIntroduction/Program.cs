using NullableIntroduction;

public
class Program
{
    static void Main()
    {
        var surveyRun = new SurveyRun();
        surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever thrown a NullReferenceException?");
        surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happened?"));
        surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");
        surveyRun.AddQuestion(QuestionType.Text, default); // should show a warning

        surveyRun.PerformSurvey(50);
    }
}