using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    private HUD gm;
    private Persist persist;
    public TopDown_AnimatorController a;
    void Start()
    {
        gm = GameObject.FindObjectOfType<HUD>();
    }
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CoinBehaviour cb = other.gameObject.GetComponent<CoinBehaviour>();
            if (!cb.inv)
            {
                gm.coins += Mathf.FloorToInt(Mathf.Pow(5, other.gameObject.transform.localScale.x - 1));
                other.gameObject.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("Axe"))
        {
            gm.hasAxe = true;
            a.SwitchToAxe();
            other.gameObject.SetActive(false);
        }
    }
    
}
