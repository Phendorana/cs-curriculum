using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float timerMax = 2;
    private float timer;
    private Vector3 target;
    private GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = GameObject.Find("Turret_Projectile");
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
        if (other.CompareTag("Player") & timer < 0)
        {
            Instantiate(projectile, transform);
            timer = timerMax;
        }
    }

}
