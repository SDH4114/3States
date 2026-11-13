using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public static float badHealth = 5f; // Количество жизней (здоровья) объекта
    public string TagAir, TagIce, TagWater; // Теги объектов, с которыми будет проверяться столкновение
    private damAttack dam; // Ссылка на скрипт DamAttack
    public GameObject boss; // Ссылка на объект босса
    public Transform[] pois; // Массив позиций для перемещения
    public GameObject outDoor;

    void Start()
    {
        StartCoroutine(FindDamAttack()); // Запускаем поиск DamAttack
    }

    IEnumerator FindDamAttack()
    {
        while (dam == null)
        {
            dam = FindObjectOfType<damAttack>(); // Ищем объект

            if (dam == null)
            {
                Debug.LogWarning("DamAttack не найден! Повторный поиск...");
                yield return new WaitForSeconds(0.5f); // Ждем 0.5 сек перед повторным поиском
            }
        }
        Debug.Log("DamAttack найден!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagAir) || collision.CompareTag(TagIce) || collision.CompareTag(TagWater))
        {
            badHealth--; // Уменьшаем здоровье на 1

            if (pois != null && pois.Length >= 5)
            {
                int index = Mathf.Clamp((int)badHealth, 0, pois.Length - 1);
                transform.position = pois[index].position;

                if (dam != null)
                {
                    dam.SpawnPrefab();
                }
            }

            if (badHealth <= 0 && boss != null)
            {
                Destroy(boss);
                Destroy(outDoor);
                Destroy(gameObject);
                Debug.Log("Босс уничтожен!");
            }
        }
    }
}