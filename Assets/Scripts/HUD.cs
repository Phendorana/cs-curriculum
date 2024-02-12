using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD gm;
    public int coins;
    public TextMeshProUGUI coinText;
    public bool hasAxe;
    
    private void Awake()
    {
        if (gm != null & gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        coins = 0;
        hasAxe = false;
    }
    void Update()
    {
        coinText.text = "Coins: " + coins;
    }
}
