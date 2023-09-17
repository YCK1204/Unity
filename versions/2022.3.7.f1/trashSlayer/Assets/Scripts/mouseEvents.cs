using Unity.VisualScripting;
using UnityEngine;

public class mouseEvents : MonoBehaviour
{
    // private float moveSpeed = 5.0f;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float nx = Mathf.Clamp(mousePosition.x, -2.5f, 2.5f);

        transform.position = new Vector3(nx, -4.0f, 0);
        // if (-3.5f <= mouseX && mouseX <= 3.5f)
        //     transform.position = new Vector3(mouseX, -4.0f, 0);

        // if (Input.GetKey(KeyCode.LeftArrow))
        //     move(-moveSpeed * Time.deltaTime);
        // else if (Input.GetKey(KeyCode.RightArrow))
        //     move(moveSpeed * Time.deltaTime);
        // Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    // void    move(float nextStep) {
    //     float x = transform.position.x;

    //     if (x + nextStep >= -3.5f && x + nextStep <= 3.5f) {
    //         transform.position = new Vector3(x + nextStep, -4.0f, 0);
    //     }
    // }
}
