using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Controller : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rBody;
    private SpriteRenderer sr;
    public int Hp = 100;
    private int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0) { return; }
        //使敌人以deltatime * 0.2 * dir的向量移动
        transform.Translate(Vector2.left * Time.deltaTime * 0.2f * dir);
    }
    //敌人的碰撞:使用碰撞回调方法
    //Collision2D collision:与敌人产生碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //dir正负碰撞
        dir = -dir;
        //敌人烈焰蛇的死亡判定:1.攻击者为玩家 2.使用武器攻击
        if(collision.collider.tag == "player")
        {
            if (collision.contacts[0].normal == Vector2.left || collision.contacts[0].normal == Vector2.right)
            {
                collision.collider.GetComponent<PlayerControl>().Hp = collision.collider.GetComponent<PlayerControl>().Hp - 20;
            }
        }
    }
}   
