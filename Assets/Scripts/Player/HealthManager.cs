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
    public TopDown_AnimatorController anim;
    public Platformer_Animator caveAnim;
    private PlayerMovement mov;
    private bool attacking;
    void Start()
    {
        gm = FindObjectOfType<HUD>();
        mov = GetComponent<PlayerMovement>();
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
        if ((mov.overworld && anim.IsAttacking) || (!mov.overworld && caveAnim.IsAttacking))
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }
        if (itime == 0 && (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Spikes")) && attacking)
        {
            gm.health -= 1;
            itime += Time.deltaTime;
        }
    }
}
