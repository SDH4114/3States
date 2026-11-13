using System.Collections;
using UnityEngine;

public class randomAtt : MonoBehaviour
{
    public float interval = 20f; // Интервал в секундах

    public ship shi; // Объект класса Ship
    public MegaDash MDa; // Объект класса MegaDash

    void Start()
    {
        StartCoroutine(ChooseRoutine());
    }

    IEnumerator ChooseRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            int choice = Random.Range(0, 3);

            if (choice == 0 && shi != null)
            {
                StartCoroutine(shi.RepeatActivation());
                Debug.Log("Выбран Ship: запущена корутина RepeatActivation()");
            }
            else if (choice == 1 && MDa != null)
            {
                StartCoroutine(MDa.MoveRoutine());
                Debug.Log("Выбран MegaDash: запущена корутина MoveRoutine()");
            }
            else if (choice == 2 && MDa != null && shi != null)
            {
                StartCoroutine(shi.RepeatActivation());
                StartCoroutine(MDa.MoveRoutine());
            }
        }
    }
}