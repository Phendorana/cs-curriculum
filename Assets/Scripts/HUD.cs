using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public CollectCoins purse;
    public HealthManager healthManager;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI hpText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + purse.coins;
        hpText.text = "Health: " + healthManager.health;
    }
}
