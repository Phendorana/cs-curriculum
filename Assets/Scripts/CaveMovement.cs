using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CaveMovement : MonoBehaviour
{
    float speed = 4;
    [SerializeField] float jump = 10;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if ( & (Input.GetAxis("Vertical") > 0 | Input.GetButton("Jump")))
        {
            rb.AddForce(Vector2.up * jump);
        }
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
    }
    
}
