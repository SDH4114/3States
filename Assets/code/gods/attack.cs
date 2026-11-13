using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public GameObject lighP; // Префаб пули
    public Transform[] firePoints; // Массив точек, откуда появляются пули
    public Transform[] targetPoints; // Массив точек, в направлении которых летят пули
    public float speed; // Скорость полета пули
    public float fireRate; // Частота стрельбы (количество выстрелов в секунду)
    private float nextFireTime = 0f; // Время, когда можно будет снова стрелять

    void Update()
    {
        // Проверяем, можно ли стрелять (прошло ли достаточно времени с последнего выстрела)
        if (Time.time >= nextFireTime)
        {
            Shoot(); // Вызываем метод стрельбы
            nextFireTime = Time.time + 1f / fireRate; // Устанавливаем время для следующего выстрела
        }
    }

    void Shoot()
    {
        // Проверяем, задан ли префаб пули и одинаковое ли количество точек спавна и целей
        if (lighP == null || firePoints.Length != targetPoints.Length) return;

        // Перебираем все точки спавна
        for (int i = 0; i < firePoints.Length; i++)
        {
            // Проверяем, заданы ли корректные точки спавна и цели
            if (firePoints[i] == null || targetPoints[i] == null) continue;

            // Вычисляем направление движения пули (от точки спавна к цели)
            Vector2 direction = (targetPoints[i].position - firePoints[i].position).normalized;

            // Устанавливаем поворот пули в зависимости от её позиции
            Quaternion bulletRotation = Quaternion.identity;
            if (i == 0 || i == 1)
                bulletRotation = Quaternion.Euler(0, 0, -30); // Пули под углом -30 градусов
            else if (i == 3 || i == 4)
                bulletRotation = Quaternion.Euler(0, 0, 30); // Пули под углом 30 градусов
            else if (i == 2)
                bulletRotation = Quaternion.Euler(0, 0, 0); // Центральная пуля летит прямо

            // Создаем пулю в точке firePoints[i] с заданным поворотом
            GameObject bullet = Instantiate(lighP, firePoints[i].position, bulletRotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Если у пули есть компонент Rigidbody2D, задаем ей скорость
            if (rb != null)
            {
                rb.velocity = direction * speed;
            }
        }
    }
}