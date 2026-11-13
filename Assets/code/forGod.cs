using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forGod : MonoBehaviour
{
    public GameObject lighP;
    public Transform[] firePoints; // Точки появления пуль
    public Transform[] targetPoints; // Точки, куда летят пули
    public float speed;
    public float fireRate;
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
        if (lighP == null || firePoints.Length != targetPoints.Length) return;

        for (int i = 0; i < firePoints.Length; i++)
        {
            if (firePoints[i] == null || targetPoints[i] == null) continue;
            Vector2 direction = (targetPoints[i].position - firePoints[i].position).normalized;

            Quaternion bulletRotation = Quaternion.identity;
            if (i == 0 || i == 1)
                bulletRotation = Quaternion.Euler(0, 0, -30);
            else if (i == 3 || i == 4)
                bulletRotation = Quaternion.Euler(0, 0, 30);
            else if (i == 2)
                bulletRotation = Quaternion.Euler(0, 0, 0);

            GameObject bullet = Instantiate(lighP, firePoints[i].position, bulletRotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = direction * speed;
            }
        }
    }
}