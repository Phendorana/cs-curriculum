using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown_AnimatorController : MonoBehaviour
{
    [SerializeField]
    RuntimeAnimatorController animShovel;

    [SerializeField]
    RuntimeAnimatorController animAxe;

    public bool IsAttacking;

    Animator anim;
    SpriteRenderer sprite;

    private float timer = 0; //Attack timer
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = animShovel;
        sprite = GetComponent<SpriteRenderer>();

        //start off facing to the right.
        anim.SetBool("IsWalking", false);
        anim.SetInteger("WalkDir", 2);
        sprite.flipX = true;

    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
            {
                anim.SetBool("IsWalking", true);
                if (Input.GetAxis("Horizontal") > 0)
                {
                    anim.SetInteger("WalkDir", 1);
                    sprite.flipX = true;
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    anim.SetInteger("WalkDir", 1);
                    sprite.flipX = false;
                }
            }
            else
            {
                anim.SetBool("IsWalking", true);
                if (Input.GetAxis("Horizontal") > 0)
                {
                    anim.SetInteger("WalkDir", 1);
                    sprite.flipX = true;
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    anim.SetInteger("WalkDir", 1);
                    sprite.flipX = false;
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    anim.SetInteger("WalkDir", 0);
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    anim.SetInteger("WalkDir", 2);
                }
            }
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetMouseButton(0))
        {
            timer = 0.5f;
            anim.SetTrigger("Attack");
            anim.SetBool("IsWalking", false);
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                anim.SetBool("Attack", false);
            }
        }
        IsAttacking = anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"); //Whether or not the player is attacking
    }
    // Call this function when the player picks up the axe.
    public void SwitchToAxe()
    {
        anim.runtimeAnimatorController = animAxe;
    }
    // Call this function to set the weapon back to a shovel.
    public void SwitchToShovel()
    {
        anim.runtimeAnimatorController = animShovel;
    }
}