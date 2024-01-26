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
    private TopDown_AnimatorController anim;
    void Start()
    {
        gm = GameObject.FindObjectOfType<HUD>();
        anim = GetComponent<TopDown_AnimatorController>();
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
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (itime == 0 && other.gameObject.CompareTag("Enemy") && !anim.IsAttacking)
        {
            gm.health -= 1;
            itime += Time.deltaTime;
        }
    }
}
