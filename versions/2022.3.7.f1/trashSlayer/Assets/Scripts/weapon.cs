using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;

    public float damage = 1f;

    [SerializeField]
    private float moveSpeed;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

}
