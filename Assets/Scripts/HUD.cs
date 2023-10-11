using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameManager gm;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI hpText;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + gm.purse.coins;
        hpText.text = "Health: " + gm.healthManager.health;
    }
}
