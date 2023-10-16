using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private HUD gm;
    private float itime = 0; //How long player has been invincible for
    private float ilength = 1.5f; //How long player will be invincible for
    //private Sprite sprite;
    //private SpriteRenderer sr; //The renderer attached to the sprite
    //private Color ogColor; //Original color
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<HUD>();
        //sprite = GetComponent<Sprite>();
        //sr = sprite.GetComponent<SpriteRenderer>();
        //ogColor = sr.color;
        //sr.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (itime > 0) //If timer in progress
        {
            itime += Time.deltaTime; //Increase timer
            //sr.color = Color.red;
            if (itime > ilength) //If timer finished
            {
                itime = 0; //Reset
                //sr.color = ogColor;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (itime == 0 & other.gameObject.CompareTag("Spikes"))
        {
            gm.health -= 1;
            itime += Time.deltaTime;
        }
    }
}
