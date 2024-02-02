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
    private Vector2 move;
    private Rigidbody2D rb;
    private Collider2D col;
    private RaycastHit2D hit;
    public Vector3 offset;
    private Scene scene;
    public Vector2 vel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        vel = Vector2.down;
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
                if (Input.GetAxis("Vertical") > 0 || Input.GetButton("Jump"))
                {
                    yVel = 8;
                }
            }
            else
            {
                yVel -= 20 * Time.deltaTime;
            }
        }
        move = new Vector2(xVel, yVel);
        /*if (!overworld)
        {
            offset = new Vector3(Mathf.Sign(xVel) * col.bounds.extents.x, Mathf.Sign(yVel) * col.bounds.extents.y + 0.27f, 0);
            hit = Physics2D.Raycast(transform.position + offset, move.normalized * Time.deltaTime);
            if (hit.distance < move.magnitude * Time.deltaTime + 0.001f)
            {
                move = move.normalized * hit.distance;
            }
        }*/

        transform.Translate(move * Time.deltaTime);
        #endregion
        
        
        if (xVel != 0 || yVel != 0) //Know which direction player is moving
        {
            vel = move;
        }
    }
}
