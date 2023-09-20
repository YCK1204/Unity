using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    GameObject gameOverPanel;

    public bool gameOver = false;

    public static GameManager instance = null;

    private int amountCoin = 0;

    [HideInInspector]
    public int currentLevel = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void collectCoin()
    {
        amountCoin++;
        text.SetText("x " + amountCoin.ToString());

        if (amountCoin % 5 == 0)
        {
            Player player = FindObjectOfType<Player>();
            levelUp(player);
        }
    }

    public void levelUp(Player player)
    {
        currentLevel++;
        shootWeapon Weapon = FindObjectOfType<shootWeapon>();
        if (currentLevel >= Weapon.Weapons.Length)
        {
            currentLevel = Weapon.Weapons.Length - 1;
        }
    }

    public void activeGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void GameOver()
    {
        instance.gameOver = true;
        instance.activeGameOverPanel();
        activeGameOverPanel();
    }

    public void playAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
