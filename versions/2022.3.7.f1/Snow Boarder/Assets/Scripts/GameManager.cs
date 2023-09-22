using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager manager = null;
    [HideInInspector]
    public bool GameOver = false;

    private void Awake()
    {
        if (manager == null)
            manager = this;
    }

    public void LoadScene()
    {
        GameOver = true;
        Invoke("Load", 1f);
    }

    public void Load()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
