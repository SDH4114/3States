using UnityEngine;

public class InfiniteCorridor : MonoBehaviour
{
    public string TagAir, TagIce, TagWater; // Теги для проверки столкновения
    public Transform starerPoint; // Точка телепортации

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag(TagAir) || collision.CompareTag(TagIce) || collision.CompareTag(TagWater)))
        {
            if (starerPoint != null)
            {
                collision.transform.position = starerPoint.position; 
            }
        }
    }
}