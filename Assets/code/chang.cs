using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; // Добавляем Cinemachine

public class Chang : MonoBehaviour
{
    public GameObject[] characters; // Массив персонажей
    public CinemachineVirtualCamera virtualCamera; // Cinemachine камера
    private int currentIndex = 0; // Индекс текущего персонажа
    public bool waterTurn, iceTurn, airTurn;

    void Start()
    {
        ActivateCharacter(currentIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && waterTurn) SwitchCharacter(0);
        if (Input.GetKeyDown(KeyCode.Alpha2) && airTurn) SwitchCharacter(1);
        if (Input.GetKeyDown(KeyCode.Alpha3) && iceTurn) SwitchCharacter(2);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentIndex == 0)
            {
                SwitchCharacter(3);
            }
            else if (currentIndex == 3)
            {
                SwitchCharacter(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchCharacter(4);
        }
    }
    void SwitchCharacter(int newIndex)
    {
        if (newIndex == currentIndex || newIndex < 0 || newIndex >= characters.Length) return;

        Vector3 lastPosition = characters[currentIndex].transform.position; // Запоминаем позицию старого персонажа

        // Отключаем всех персонажей
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }

        // Включаем нового персонажа
        currentIndex = newIndex;
        characters[currentIndex].SetActive(true);
        characters[currentIndex].transform.position = lastPosition; // Перемещаем персонажа на позицию предыдущего

        FollowWithCinemachine();
    }

    void FollowWithCinemachine()
    {
        if (virtualCamera != null && characters[currentIndex] != null)
        {
            virtualCamera.Follow = characters[currentIndex].transform;
        }
    }

    void ActivateCharacter(int index)
    {
        if (index < 0 || index >= characters.Length) return;

        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == index);
        }
        FollowWithCinemachine();
    }
}
