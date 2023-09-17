using UnityEngine;

public class fallBackground : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < -10.0f) {
            transform.position = new Vector3(0, 10.0f, 0);
        }
    }
}
