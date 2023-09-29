using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CaveMovement : MonoBehaviour
{
    float speed = 4;
    private float grav = 3;
    private float jump;
    private float yVel;
    private Vector3 move;
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (grounded & (Input.GetAxis("Vertical") == 1 | Input.GetButton("Jump")))
        {
            yVel += jump;
        }
        if (yVel > 0)
        {
            yVel -= grav;
        }
        move = new Vector3(Input.GetAxis("Horizontal") * speed, yVel, 0) * Time.deltaTime;
        transform.Translate(move);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
