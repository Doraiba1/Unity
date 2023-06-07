using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rBody;
    private SpriteRenderer sr;
    public int Hp = 100;
    private bool isGround = true;
    public float MoveSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ani.SetFloat("Speed", MoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0) { return; }
        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal == 0)
        {
            MoveSpeed = 0.0f;
            ani.SetFloat("Speed", MoveSpeed);
        }
        if (horizontal != 0)
        {
            MoveSpeed = 20.0f;
            ani.SetFloat("Speed", 20.0f);
            transform.Translate(transform.right * MoveSpeed * Time.deltaTime * horizontal);
            //Íæ¼Ò×ªÏò
            if (horizontal < 0)
            {
                sr.flipX = false;
            }
            if (horizontal > 0)
            {
                sr.flipX = true;
            }
        }
        //else
        //{
        //    ani.SetFloat("Speed", MoveSpeed);
        //}
        if (Input.GetKeyDown(KeyCode.J) && isGround == true)
        {
            ani.SetTrigger("Is attack");
        }
    }
}
