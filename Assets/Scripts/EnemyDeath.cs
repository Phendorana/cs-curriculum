using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
