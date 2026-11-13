using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openTheDoor : MonoBehaviour
{
    public string TagAir, TagIce, TagWater; 
    public GameObject objectToDestroy; // Какой объект уничтожить (можно указать другой)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag(TagAir) || collision.CompareTag(TagIce) || collision.CompareTag(TagWater))) // Если объект имеет нужный тег
        {
            Destroy(objectToDestroy); // Уничтожаем указанный объект
            Destroy(gameObject);
        }
    }
}
