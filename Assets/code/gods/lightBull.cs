using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBull : MonoBehaviour
{
    public float lifeTime = 5f;  // Время жизни объекта перед уничтожением
    public string[] states; // Массив тегов, при столкновении с которыми будет телепорт
    public float teleportX = 2.4f;  // Координата X для телепортации
    public float teleportY = -1.6f; // Координата Y для телепортации

    void Start()
    {
        Destroy(gameObject, lifeTime); // Уничтожаем объект через lifeTime секунд
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (states.Length == 0) return; // Проверяем, заданы ли теги

        foreach (string tag in states)
        {
            if (collision.CompareTag(tag))
            {
                damage.badHealth = 5;
                collision.transform.position = new Vector3(teleportX, teleportY, collision.transform.position.z);
                break; // Прерываем, чтобы не проверять лишнее
            }
        }
    }
}