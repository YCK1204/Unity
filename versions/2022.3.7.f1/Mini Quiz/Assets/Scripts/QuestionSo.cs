using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSo : ScriptableObject
{
/* variables */

    [TextArea(2,6)]
    [SerializeField] string question = "Enter your question";

    [SerializeField]
    private string[] answers = new string[4];

    [SerializeField]
    private int correctAnswer;

/* variables */


/* functions */

    public string GetQuestionText()
    {
        return question;
    }

    public string GetCorrectAnswer()
    {
        return answers[correctAnswer];
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerindex()
    {
        return correctAnswer;
    }

/* functions */

}
