using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Horizontal
//Vertical

public class Delivery : MonoBehaviour
{
    float   steerSpeed = 200f;
    float   moveSpeed = 10f;
    float   destoryDelay = 1f;
    bool    hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float steerAmount = steerSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveAmount = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Target" && !hasPackage)
        {
            Debug.Log("picked up target!");
            hasPackage = true;
            spriteRenderer.color = target.GetComponent<SpriteRenderer>().color;
        }
        if (target.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered!");
            hasPackage = false;
            spriteRenderer.color = target.GetComponent<SpriteRenderer>().color;
            Destroy(target.gameObject, destoryDelay);
        }
    }
}