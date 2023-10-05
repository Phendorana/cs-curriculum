using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public CollectCoins purse;
    public HealthManager healthManager;
    private TextMeshProUGUI coinText;
    private TextMeshProUGUI hpText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = purse.coins.ToString();
        hpText.text = healthManager.health.ToString();
    }
}
