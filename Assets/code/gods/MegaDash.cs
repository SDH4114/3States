using System.Collections;
using UnityEngine;

public class MegaDash : MonoBehaviour
{
    public Transform[] points; // Массив точек
    public float speed = 2f; // Скорость движения
    private Vector3 startPosition; // Запоминаем начальную позицию

    public string[] states; // Массив тегов, при столкновении с которыми будет телепорт
    public float teleportX = 22f;  // Координата X для телепортации
    public float teleportY = 20f;  // Координата Y для телепортации

    public attack att; // Ссылка на скрипт атаки

    void Start()
    {
        startPosition = transform.position; // Запоминаем начальную точку
    }

    public IEnumerator MoveRoutine()
    {
        if (att != null) att.enabled = false; // Включаем скрипт атаки

        for (int i = 0; i < points.Length; i++)
        {
            yield return StartCoroutine(MoveToTarget(points[i].position));
        }
        for (int i = points.Length - 2; i >= 0; i--)
        {
            yield return StartCoroutine(MoveToTarget(points[i].position));
        }

        // Возвращаемся в исходную позицию
        yield return StartCoroutine(MoveToTarget(startPosition));

        if (att != null) att.enabled = true; // Выключаем атаку после завершения движения
    }

    IEnumerator MoveToTarget(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in states)
        {
            if (collision.CompareTag(tag))
            {
                damage.badHealth = 5;
                collision.transform.position = new Vector3(teleportX, teleportY, collision.transform.position.z);
                return; // Прерываем после первого совпадения
            }
        }
    }
}