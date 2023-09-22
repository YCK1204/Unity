using UnityEngine;
public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.manager.GameOver)
        {
            if (other.tag == "Player")
            {
                GetComponent<AudioSource>().Play();
                GameManager.manager.LoadScene();
            }
        }
    }
}
