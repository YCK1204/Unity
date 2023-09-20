using UnityEngine;

public class Player : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)  {
        if (other.tag == "Enemy" || other.tag == "Boss") {
            Destroy(gameObject);
            GameManager.instance.GameOver();
        } else if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameManager.instance.collectCoin();
        }
    }
}
