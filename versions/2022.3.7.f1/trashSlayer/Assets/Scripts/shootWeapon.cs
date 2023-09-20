using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shootWeapon : MonoBehaviour
{
    [SerializeField]
    public GameObject []Weapons;

    [SerializeField]
    private float createTerm;

    [SerializeField]
    private Transform weaponTransform;
    private float lastShootTime = 0f;


    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            if (Time.time - lastShootTime > createTerm) {
                lastShootTime = Time.time;
                GameManager instance = FindObjectOfType<GameManager>();
                int level = instance.currentLevel;
                Instantiate(Weapons[level], weaponTransform.position, Quaternion.identity);
            }
        }
    }
}
