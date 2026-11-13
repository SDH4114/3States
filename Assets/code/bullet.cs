using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    public float lifeTime = 3f; // Время жизни пули
    public string TagAir, TagIce, TagWater; // Теги для проверки столкновения


    void Start()
    {
        Destroy(gameObject, lifeTime); // Уничтожаем пулю через указанное время
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagAir) || collision.CompareTag(TagIce) || collision.CompareTag(TagWater))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
