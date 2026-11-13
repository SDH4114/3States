using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marhrut : MonoBehaviour
{
public Transform[] waypoints; // Точки маршрута
    public float speed = 5f; // Скорость движения

    private int currentIndex = 0;
    private bool reverse = false; // Флаг для движения назад

    void Start()
    {
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position; // Начальная позиция
            StartCoroutine(MoveAlongWaypoints());
        }
        else
        {
            Debug.LogWarning("WaypointMover: Точки маршрута не заданы!");
        }
    }

    private IEnumerator MoveAlongWaypoints()
    {
        while (true)
        {
            yield return StartCoroutine(MoveToTarget(waypoints[currentIndex].position));

            // Проверяем, достигли ли конца или начала маршрута
            if (!reverse)
            {
                if (currentIndex < waypoints.Length - 1)
                {
                    currentIndex++;
                }
                else
                {
                    reverse = true;
                    currentIndex--;
                }
            }
            else
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                }
                else
                {
                    reverse = false;
                    currentIndex++;
                }
            }
        }
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
    }
}
