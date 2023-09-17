using UnityEngine;

public class enemy : MonoBehaviour
{
    private float moveSpeed = 10f;

    [SerializeField]
    private float hp;
    void Update() {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < -5.5f)
            Destroy(gameObject);
    }

    public void setMoveSpeed(float moveSpeed) {
        this.moveSpeed += moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Weapon") {
            GameObject Weapon = other.gameObject;
            weapon weapon = Weapon.GetComponent<weapon>();
            beAttack(weapon.damage);        
            Destroy(other.gameObject);
        }
    }

    void beAttack(float damage) {
        this.hp -= damage;
        if (this.hp <= 0) {
            Destroy(gameObject);
        }
    }
}
