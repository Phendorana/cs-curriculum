using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    HUD gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            gm.coins += Mathf.FloorToInt(Mathf.Pow(5, other.gameObject.transform.localScale.x - 1));
            other.gameObject.SetActive(false);
        }
    }
    
}
