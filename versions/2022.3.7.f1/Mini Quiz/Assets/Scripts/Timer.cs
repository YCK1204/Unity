using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
/* variables */

    [SerializeField]
    private float timeToCompleteQuestion = 30f;

    [SerializeField]
    private float timeToShowCorrectAnswer = 10f;

    private bool isAnsweringQuestion = true;
    private float timerValue;
    private float fillAmount;
    private Image timerImage;

    GameManager manager;

/* variables */

/* functions */

    private void Start()
    {
        manager = GameManager.manager;
        timerValue = timeToCompleteQuestion;
        timerImage = GetComponent<Image>();
        manager.SetStartSection(true);
        manager.SetEndSection(false);
    }

    void Update()
    {
        if (manager.GetGameOver() == false)
        {
            if (manager.GetEndSection() == true && isAnsweringQuestion == true)
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
            UpdateTimer();
            timerImage.fillAmount = fillAmount;
        }
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillAmount = timerValue / timeToCompleteQuestion;
            }
            else
            {
                timerValue = timeToShowCorrectAnswer;
                isAnsweringQuestion = false;
                manager.SetEndSection(true);
                fillAmount = 0;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillAmount = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                manager.SetStartSection(false);
                manager.SetEndSection(false);
                fillAmount = 0;
            }
        }
    }

/* functions */
}
