using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrRight : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint; // Точка выстрела
    public float bulletSpeed = 10f; // Скорость пули
    public float fireRate = 1f; // Частота стрельбы (выстрелы в секунду)
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 90); // Вращение на 90 градусов по оси Z
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = -firePoint.right * bulletSpeed; // Двигаем пулю влево
        }
    }
}
