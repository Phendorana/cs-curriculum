using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

public class Turret : MonoBehaviour
{
    float timerMax = 2;
    float timer;
    public Fireball fireball;
    void Start()
    {
        timer = timerMax;
    }
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && timer <= 0)
        {
            Fireball f = Instantiate(fireball, transform.position + new Vector3(0, 0.1f), quaternion.identity);
            f.velocity = (other.gameObject.transform.position - transform.position).normalized * 10;
            f.gameObject.transform.tag = "Enemy";
            f.creator = gameObject;
            timer = timerMax;
        }
    }

}
