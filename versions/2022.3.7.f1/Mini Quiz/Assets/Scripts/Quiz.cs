using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
/* variables */

    GameManager manager;

    [SerializeField]
    TextMeshProUGUI questionText;

    QuestionSo currentQuestion;

    [SerializeField]
    GameObject[] answerButtonGameObject;

    [SerializeField]
    Sprite defaultSprite;

    [SerializeField]
    Sprite currentSprite;

    [SerializeField]
    Sprite correctSprite;

    int correctButtonIndex;

/* variables */

/* functions */

    private void SetQuestion()
    {
        if (manager.GetCurrentLevel() < manager.GetMaxLevel() - 1)
        {
            manager.IncreaseLevel();
            currentQuestion = manager.GetQuestion();
            correctButtonIndex = currentQuestion.GetCorrectAnswerindex();
            manager.SetStartSection(true);
            InitializeButtonTMP();
        }
        else
        {
            manager.SetGameOver();
            manager.SetActiveGameoverCanvas(true);
        }
    }

    private void Start()
    {
        manager = GameManager.manager;
        currentQuestion = manager.GetQuestion();
        correctButtonIndex = currentQuestion.GetCorrectAnswerindex();
        InitializeButtonTMP();
    }

    private void Update()
    {
        if (manager.GetGameOver() == false)
        {
            UpdateSection();
        }
    }

    private void UpdateSection()
    {
        if (manager.GetEndSection() == false)
        {
            if (manager.GetStartSection() == true)
            {
                questionText.text = currentQuestion.GetQuestionText();
            }
            else
            {
                SetQuestion();
                SetDefaultSpriteButtons();
            }
        }
    }

    private void InitializeButtonTMP()
    {
        for (int i = 0; i < answerButtonGameObject.Length; i++)
        {
            TextMeshProUGUI buttonTMP = answerButtonGameObject[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonTMP.text = currentQuestion.GetAnswer(i);
            buttonTMP.fontSize = 48;
            buttonTMP.color = new Color(0, 0, 0, 255);
        }
    }

    private void SetDefaultSpriteButtons()
    {
        for (int i = 0; i < answerButtonGameObject.Length; i++)
        {
            Button button = answerButtonGameObject[i].GetComponent<Button>();
            button.image.sprite = defaultSprite;
            button.image.color = Color.white;
        }
    }

    public void OnClickAnswerButton(int index)
    {
        if (manager.GetEndSection() == false)
        {
            SetDefaultSpriteButtons();
            Button button = answerButtonGameObject[index].GetComponent<Button>();

            button.image.sprite = currentSprite;
            if (index == currentQuestion.GetCorrectAnswerindex())
            {
                questionText.text = "Correct!   :)";
                manager.IncreaseScore();
            }
            else
            {
                questionText.text = currentQuestion.GetQuestionText() + "\n => " + currentQuestion.GetCorrectAnswer() + "       :(";
                Button correctButton = answerButtonGameObject[correctButtonIndex].GetComponent<Button>();
                correctButton.image.color = Color.yellow;
            }
            manager.SetEndSection(true);
        }
    }

/* functions */

}
