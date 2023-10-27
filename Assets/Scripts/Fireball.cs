using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector2 velocity;
    public GameObject creator;
    float deathTimer = 0.1f;
    public bool dying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
        if (dying)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer < 0)
            {
                gameObject.SetActive(false);
            }
        }
        if (transform.position.magnitude > 1000)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject != creator)
        {
            dying = true;
        }
        //print(other.gameObject.name);
    }
}
