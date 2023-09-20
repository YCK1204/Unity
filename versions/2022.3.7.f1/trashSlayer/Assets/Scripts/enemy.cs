using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
     float moveSpeed = 10f;
    [SerializeField]
    GameObject Coin;

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
            beAttacked(weapon.damage);
            Destroy(other.gameObject);
        }
    }
    

    void beAttacked(float damage) {
        this.hp -= damage;
        if (this.hp <= 0) {
            Coin.transform.position = gameObject.transform.position;
            Instantiate(Coin);
            Destroy(gameObject);
            if (gameObject.tag == "Boss")
                GameManager.instance.GameOver();
        }
    }

    

    //private void OnDestroy()
    //{
    //    Resources.UnloadUnusedAssets();
    //}
}
