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
        //ʹ������deltatime * 0.2 * dir�������ƶ�
        transform.Translate(Vector2.left * Time.deltaTime * 0.2f * dir);
    }
    //���˵���ײ:ʹ����ײ�ص�����
    //Collision2D collision:����˲�����ײ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //dir������ײ
        dir = -dir;
        //���������ߵ������ж�:1.������Ϊ��� 2.ʹ����������
        if(collision.collider.tag == "player")
        {
            if (collision.contacts[0].normal == Vector2.left || collision.contacts[0].normal == Vector2.right)
            {
                collision.collider.GetComponent<PlayerControl>().Hp = collision.collider.GetComponent<PlayerControl>().Hp - 20;
            }
        }
    }
}   
