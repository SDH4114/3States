using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class igle : MonoBehaviour
{
    public string TagAir, TagIce, TagWater; 
    public float teleportX = 22f;  // Координата X для телепортации
    public float teleportY = 20f; // Координата Y для телепортации

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagAir) || collision.CompareTag(TagIce) || collision.CompareTag(TagWater))
        {
            damage.badHealth = 5;
            collision.transform.position = new Vector3(teleportX, teleportY, collision.transform.position.z);
        }
    }
}
