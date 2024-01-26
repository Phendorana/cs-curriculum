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
    private HUD gm;
    private TopDown_AnimatorController playerAnim;
    private PlayerMovement pmove;
    public bool shovelImmunity;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<HUD>();
        playerAnim = FindObjectOfType<TopDown_AnimatorController>();
        pmove = FindObjectOfType<PlayerMovement>();
    }

    private void Die()
    {
        switch (R.Range(0, 3))
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Weapon")) //On hit by player
        {
            Die();
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("a");
            bool inWeaponPath = false;
            if (pmove.vel.x > 0) //If player is facing right
            {
                if (transform.position.x > pmove.gameObject.transform.position.x) //If we are to the right of the player
                {
                    inWeaponPath = true;
                }
            }
            else if (transform.position.x <
                     pmove.gameObject.transform.position.x) //Player's not facing right, and we are to the left of them
            {
                inWeaponPath = true;
            }

            if (pmove.vel.y > 0) //If player is facing up
            {
                if (transform.position.y > pmove.gameObject.transform.position.y) //If we are above the player
                {
                    inWeaponPath = true;
                }
            }
            else if (transform.position.y <
                     pmove.gameObject.transform.position.y) //Player's not facing up, and we are below them
            {
                inWeaponPath = true;
            }

            if (inWeaponPath && playerAnim.IsAttacking && ((shovelImmunity && gm.hasAxe) || !shovelImmunity))
            {
                Die();
            }
        }
    }
}
