using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coins += 1;
            other.gameObject.SetActive(false);
        }
    }
}
