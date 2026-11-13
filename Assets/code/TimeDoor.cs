using System.Collections;
using UnityEngine;

public class TimeDoor : MonoBehaviour
{
    public string TagAir, TagIce, TagWater; 
    public GameObject objectToMove; // Объект, который будет телепортироваться
    public Transform teleportPointOne; // Первая точка телепортации
    public float timer; // Время задержки перед перемещением
    public float returnTimer; // Время задержки перед возвратом

    private Vector3 originalPosition; // Исходное положение объекта
    private bool timerStarted = false; // Флаг, запущен ли таймер

    private void Start()
    {
        if (objectToMove != null)
        {
            originalPosition = objectToMove.transform.position; // Запоминаем исходную позицию
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!timerStarted && (collision.CompareTag(TagAir) || collision.CompareTag(TagIce) || collision.CompareTag(TagWater))) // Проверяем столкновение с нужным объектом
        {
            timerStarted = true;
            StartCoroutine(TeleportSequence()); // Запускаем процесс телепортации
        }
    }

    private IEnumerator TeleportSequence()
    {
        yield return new WaitForSeconds(timer); // Ждём перед первым перемещением

        // Телепортируем объект в teleportPointOne
        if (objectToMove != null && teleportPointOne != null)
        {
            objectToMove.transform.position = teleportPointOne.position;
        }

        yield return new WaitForSeconds(returnTimer); // Ждём перед возвратом

        // Возвращаем объект в исходное положение
        if (objectToMove != null)
        {
            objectToMove.transform.position = originalPosition;
        }

        timerStarted = false; // Разрешаем повторное использование триггера
    }
}