using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] bool overworld;
    private float speed = 4;
    private float xVel;
    private float yVel;
    private Rigidbody2D rb;
    private Collider2D col;
    private RaycastHit2D hit;
    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        #region Movement
        xVel = Input.GetAxis("Horizontal") * speed;
        if (overworld)
        {
            yVel = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down);
            if (hit.distance < col.bounds.extents.y)
            {
                yVel = 0;
                if (Input.GetAxis("Vertical") > 0 | Input.GetButtonDown("Jump"))
                {
                    yVel = 8;
                }
            }
            else
            {
                yVel -= 20 * Time.deltaTime;
            }
        }
        transform.Translate(new Vector3(xVel, yVel, 0f) * Time.deltaTime);
        #endregion
    }
    
    
    
}
