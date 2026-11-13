using UnityEngine;

public class Turret : MonoBehaviour
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed; // Двигаем пулю вперёд
        }
    }
}