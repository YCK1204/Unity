using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        Jump();
    }

    void Jump() {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        float force = Random.Range(2f, 8f);
        Vector2 direction = Vector2.up * force;
        rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
    }

}
