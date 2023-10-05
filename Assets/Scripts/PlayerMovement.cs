using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] bool overworld;
    private float speed = 4;
    private float xVel;
    private float yVel;
    private Rigidbody2D rb;
    private Collider2D col;
    private RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        xVel = Input.GetAxis("Horizontal") * speed;
        if (overworld)
        {
            yVel = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, col.bounds.extents.y + 0.1f);
            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                yVel = 0;
                if (Input.GetAxis("Vertical") > 0 | Input.GetButton("Jump")) //Up arrow, W key, or spacebar
                {
                    yVel += 2; //Jump
                }
            }
            else //Gravity
            {
                yVel -= 20 * Time.deltaTime;
            }
            
        }
        transform.Translate(new Vector3(xVel, yVel, 0f) * Time.deltaTime);
        
    }
    
}
