using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneMamegaer : MonoBehaviour
{
    public static int coins = 0;
    public Text coinText;

    void Start()
    {
        coins = 0;
    }
    void Update()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins.ToString();
        }
    }
}
