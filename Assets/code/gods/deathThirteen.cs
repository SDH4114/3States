using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathThirteen : MonoBehaviour
{
    public GameObject lightP; // Префаб пули
    public float spawnRate = 1f; // Частота спавна пуль (раз в сколько секунд)
    public float bulletSpeed = 5f; // Скорость движения пули

    void Start()
    {
        InvokeRepeating("SpawnBullet", 0f, spawnRate);
    }

    void SpawnBullet()
    {
        Vector3 spawnPosition = transform.position;        
        GameObject bullet = Instantiate(lightP, spawnPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;
    }
}
