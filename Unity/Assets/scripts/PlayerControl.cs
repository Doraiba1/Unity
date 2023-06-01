using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animation ani;
    private Rigidbody2D rBody;
    private SpriteRenderer sr;
    public int Hp = 100;
    private bool isGround = false;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
        rBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0) { return; }
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            transform.Translate(transform.right * 5 * Time.deltaTime * horizontal);
            if (horizontal < 0)
            {
                sr.flipX = false;
            }
            if (horizontal > 0)
            {
                sr.flipX = true;
            }
            
        }
        else
        {
            
        }
    }
}
