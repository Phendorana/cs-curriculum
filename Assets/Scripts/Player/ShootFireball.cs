using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    float cooldown = 2; //How long the cooldown timer will be each time
    float cooltime; //How long we've been cooling down for
    public Fireball fireball;
    public PlayerMovement pmove;
    void Start()
    {
        cooltime = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooltime > 0)
        {
            cooltime -= Time.deltaTime;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            Fireball f = Instantiate(fireball, transform.position, quaternion.identity);
            f.velocity = pmove.vel.normalized * 10;
            f.transform.tag = "Weapon";
            f.creator = gameObject; //Make creator equal to the player
            cooltime = cooldown; //Reset timer
        }
    }
}
