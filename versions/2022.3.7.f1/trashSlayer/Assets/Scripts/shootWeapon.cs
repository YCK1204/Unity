using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shootWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject Weapon;

    [SerializeField]
    private float createTerm;

    [SerializeField]
    private Transform weaponTransform;
    private float lastShootTime = 0f;

    void Update()
    {
        if (Time.time - lastShootTime > createTerm) {
            lastShootTime = Time.time;
            Instantiate(Weapon, weaponTransform.position, Quaternion.identity);
        }
    }
}
