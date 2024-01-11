using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using R = UnityEngine.Random;

public class EnemyDeath : MonoBehaviour
{
    public GameObject drop1;
    public GameObject drop2;
    public GameObject drop3;
    private GameObject drop;
    private float dropNum; //How many things we can drop
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
            int r = R.Range(0, 3);
            switch (r)
            {
                case 0:
                    drop = drop1;
                    break;
                case 1:
                    drop = drop2;
                    break;
                case 2:
                    drop = drop3;
                    break;
            }
            
            if (drop != null)
            {
                GameObject d = Instantiate(drop, transform.position, quaternion.identity);
            }
            gameObject.SetActive(false); //Die
        }
}
}
