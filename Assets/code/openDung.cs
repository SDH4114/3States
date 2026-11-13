using System.Collections;
using UnityEngine;

public class openDung : MonoBehaviour
{
    public string TagAir, TagIce, TagWater; 
    public GameObject door; // Дверь, которая закроется
    public GameObject bosse; // Босс, который появится
    public GameObject bossMu; // Музыка босса
    public GameObject gameMu; // Фоновая музыка
    private int bassMuCou = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagAir) || collision.CompareTag(TagIce) || collision.CompareTag(TagWater))
        {
            if (moneMamegaer.coins >= 55) // Проверяем, хватает ли монет
            {
                door.SetActive(false);

                if(bassMuCou == 1)
                {
                    if (bossMu != null)
                    {
                        Instantiate(bossMu, Vector3.zero, Quaternion.identity); // Создаём музыку босса
                        bassMuCou = 0;
                    }               
                }

                if (gameMu != null)
                {
                    Destroy(gameMu); // Удаляем фоновую музыку
                }

                if (bosse != null)
                {
                    bosse.SetActive(true); // Активируем босса
                }
                damage.badHealth = 5f; // Сбрасываем здоровье босса
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (door != null)
        {
            door.SetActive(true); // Закрываем дверь
        }
    }
}