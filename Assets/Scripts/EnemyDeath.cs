using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Weapon")) //On hit by player
        {
            GameObject d = Instantiate(drop, transform.position, quaternion.identity);
            gameObject.SetActive(false); //Die
        }
    }
}
