using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Destroy(gameObject);
            Debug.Log("sugo");
        }
    }
}
