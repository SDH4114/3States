using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipiAtack : MonoBehaviour
{
    public string[] states;
    public float teleportX = 25f;  // Координата X для телепортации
    public float teleportY = 22f; // Координата Y для телепортации

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (states.Length == 0) return; // Проверяем, заданы ли теги

        foreach (string tag in states)
        {
            if (collision.CompareTag(tag))
            {
                collision.transform.position = new Vector3(teleportX, teleportY, collision.transform.position.z);
                damage.badHealth = 5;
                break; // Прерываем, чтобы не проверять лишнее
            }
        }
    }
}
