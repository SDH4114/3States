using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mone : MonoBehaviour
{
    public string TagAir, TagIce, TagWater;
    public int moneValu;
    public GameObject auf;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagAir) || collision.CompareTag(TagIce) || collision.CompareTag(TagWater))
        {
            moneMamegaer.coins += moneValu;
            Instantiate(auf);
            Destroy(gameObject);
        }
    }
}
