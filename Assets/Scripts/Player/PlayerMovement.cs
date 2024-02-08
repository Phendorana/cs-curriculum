using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool overworld;
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
    private float sprintTimer = 0;
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
        if (Input.GetButton("Submit") && sprintTimer == 0) //Sprint
        {
            sprintTimer = 0.5f;
            speed = 10;
        }

        if (sprintTimer > 0)
        {
            sprintTimer -= Time.deltaTime;
            if (sprintTimer < 0)
            {
                sprintTimer = 0;
                speed = 4;
            }
        }
        xVel = Input.GetAxis("Horizontal") * speed; //Hori move
        if (overworld)
        {
            yVel = Input.GetAxis("Vertical") * speed; //Vert move
        }
        else //Jump
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down);
            if (hit.distance < col.bounds.extents.y)
            {
                yVel = 0;
                if (Input.GetAxis("Vertical") > 0)
                {
                    yVel = 12;
                }
            }
            else
            {
                yVel -= 20 * Time.deltaTime;
            }
        }
        move = new Vector2(xVel, yVel);
        if (!overworld && false)
        {
            offset = new Vector3(Mathf.Sign(xVel) * col.bounds.extents.x + col.offset.x, Mathf.Sign(yVel) * col.bounds.extents.y + col.offset.y, 0);
            hit = Physics2D.Raycast(transform.position + offset, move.normalized * Time.deltaTime);
            if (hit.distance < move.magnitude * Time.deltaTime + 0.001f)
            {
                move = move.normalized * hit.distance;
            }
        }
        transform.Translate(move * Time.deltaTime);
        #endregion
        if (xVel != 0 || yVel != 0) //Know which direction player is moving
        {
            vel = move;
        }
    }
}
