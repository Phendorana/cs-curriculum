using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 5;
    private float itime = 0; //How long player has been invincible for
    private float ilength = 1.5f; //How long player will be invincible for
    private Renderer rend;
    private Color ogColor; //Original color
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        ogColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (itime > 0) //If timer in progress
        {
            itime += Time.deltaTime; //Increase timer
            rend.material.color = new Color(itime, itime, itime);
            if (itime > ilength) //If timer finished
            {
                itime = 0; //Reset
                rend.material.color = ogColor;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (itime == 0 & other.gameObject.CompareTag("Spikes"))
        {
            health -= 1;
            itime += Time.deltaTime;
        }
    }
}
