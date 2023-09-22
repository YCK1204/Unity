using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float torque;
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.manager.GameOver)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                rb2d.AddTorque(torque);
            else if (Input.GetKey(KeyCode.RightArrow))
                rb2d.AddTorque(-torque);
        }
    }
}
