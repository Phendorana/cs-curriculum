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
    private float timerMax = 2;
    private float timer;
    public Rigidbody2D projectile;
    void Start()
    {
        timer = timerMax;
    }

    // Update is called once per frame
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
            Rigidbody2D p = Instantiate(projectile, transform.position + new Vector3(0, 0.1f), quaternion.identity);
            p.velocity = (other.gameObject.transform.position - transform.position).normalized * 100;
            timer = timerMax;
        }
    }

}
