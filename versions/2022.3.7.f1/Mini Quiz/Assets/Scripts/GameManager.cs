using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

/* variables */

    [SerializeField]
    QuestionSo[] questions;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    TextMeshProUGUI amountScoreText;

    [SerializeField]
    TextMeshProUGUI detailScoreText;

    [SerializeField]
    GameObject gameoverCanvas;

    public static GameManager manager = null;

    private bool startSection;
    private bool endSection;
    private bool gameOver;
    private int currentLevel = 0;
    private int maxLevel;
    private int score = 0;
    private int correctAnsweringCount = 0;

/* variables */

/* functions */
    private void Awake()
    {
        if (manager == null)
            manager = this;

        startSection = true;
        endSection = false;
        gameOver = false;
        maxLevel = questions.Length;
    }

    public void LoadDefaultScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SetActiveGameoverCanvas(bool state)
    {
        amountScoreText.text = "Your score : " + score.ToString() + " %";
        detailScoreText.text = "You got the questions right \n" + correctAnsweringCount.ToString() +
                                " out of " + questions.Length.ToString();
        gameoverCanvas.SetActive(state);
    }

    /* Set methods */
    public void IncreaseLevel()
    {
        if (currentLevel < maxLevel - 1)
            currentLevel++;
    }

    public void IncreaseScore()
    {
        correctAnsweringCount++;
        score += Mathf.RoundToInt(100 / questions.Length);
        if (correctAnsweringCount == questions.Length)
            score = 100;
        scoreText.text = score.ToString() + " %";
    }

    public void SetStartSection(bool f)
    {
        startSection = f;
    }

    public void SetEndSection(bool f)
    {
        endSection = f;
    }

    public void SetGameOver()
    {
        gameOver = true;
    }
    /* Set methods */

    /* Get methods */
    public int GetMaxLevel()
    {
        return maxLevel;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public bool GetStartSection()
    {
        return startSection;
    }

    public bool GetEndSection()
    {
        return endSection;
    }

    public QuestionSo GetQuestion()
    {
        return questions[currentLevel];
    }

    public bool GetGameOver()
    {
        return gameOver;
    }
    /* Get methods */

/* functions */
}
