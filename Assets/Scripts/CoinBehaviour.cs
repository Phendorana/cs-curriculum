using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private float timer = 1;
    private float dir = -7; //Direction and speed that timer moves in
    public bool inv = true; //Is invincible
    private SpriteRenderer sr;
    private Color backColor;
    private float size; //The size of the coin
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        backColor = new Color(175, 175, 175);
        size = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (inv)
        {
            timer += Time.deltaTime * dir;
            transform.localScale = new Vector3(timer, size, size);
            if (timer < 0)
            {
                sr.color = backColor;
            }
            else
            {
                sr.color = Color.white;
            }
            if (timer < -1)
            {
                dir *= -1;
            }
            else if (timer > 1)
            {
                inv = false;
                transform.localScale = Vector3.one * size;
            }
        }
        
    }
}
