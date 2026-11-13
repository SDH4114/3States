using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public string TagAir, TagIce, TagWater;
    private int lev;

    void Start()
    {
        // Загружаем сохранённый уровень, но не выходим за пределы доступных сцен
        lev = PlayerPrefs.GetInt("Level", SceneManager.GetActiveScene().buildIndex);

        if (lev >= SceneManager.sceneCountInBuildSettings) 
        {
            lev = 0;  // Если индекс за пределами, начинаем сначала
            PlayerPrefs.SetInt("Level", lev);
            PlayerPrefs.Save();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagAir) || collision.CompareTag(TagIce) || collision.CompareTag(TagWater))
        {
            lev++; // Переход на следующий уровень

            if (lev < SceneManager.sceneCountInBuildSettings)  
            {
                PlayerPrefs.SetInt("Level", lev);  // Сохраняем уровень
                PlayerPrefs.Save();
                SceneManager.LoadScene(lev);  // Загружаем новую сцену
            }
            else
            {
                Debug.Log("Конец игры! Все уровни пройдены.");
                PlayerPrefs.DeleteKey("Level");  // Очистка прогресса
                SceneManager.LoadScene(0);  // Перезапуск с первого уровня
            }
        }
    }
}