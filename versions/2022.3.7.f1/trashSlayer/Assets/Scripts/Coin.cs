using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        Jump();
        StartCoroutine("isInMap");
    }

    IEnumerator isInMap()
    {
        while (true)
        {
            if (transform.position.y < -5.5f)
                Destroy(gameObject);
            yield return null;
        }
    }

    void Jump() {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        float force = Random.Range(2f, 5f);
        Vector2 direction = Vector2.up * force;
        direction.x += Random.Range(-2f, 3f);
        rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
    }

}
