using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy_1_Controller : MonoBehaviour
{
    //��������
    private Animator ani;
    //�������
    private Rigidbody2D rBody;
    //������Ⱦ����
    private SpriteRenderer sr;
    //Ѫ��
    public int Hp = 100;
    //��Ҷ���
    public GameObject player;
    //�������
    private NavMeshAgent navMeshAgent;
    //���Trigger
    public GameObject trigger1;
    //����Trigger
    public GameObject trigger2;
    // �ƶ��ٶ�
    public float moveSpeed = 5f;
    // �ƶ���Χ
    public float moveRange = 5f;
    // ���˳�ʼλ�õ� X ����
    private float startXPos;
    // ��¼��ǰ�ƶ�����ı�����1 ��ʾ���ң�-1 ��ʾ����
    private int moveDirection = 1;
    //���˼����ҵľ���
    public float findRange = 10f;
    //���˹�����ҵľ���
    public float attackRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        startXPos = transform.position.x;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void FixedUpdate()
    {
        //����Ҫ�ƶ��ľ���
        float distenceToMove = moveSpeed * Time.deltaTime;

        //�ƶ�����,�������ƶ���Χ��ת�ƶ�����
        transform.position += new Vector3(distenceToMove * moveDirection, 0, 0);
        if (Mathf.Abs(transform.position.x - startXPos) > moveRange / 2)
        {
            moveDirection *= -1;
        }
        Flip();
        Attack_Player();
    }
    //���˵���ײ:ʹ����ײ�ص�����
    //OnTriggerEnter2D:����˲�����ײ

    //��ת����
    private void Flip()
    {
        bool faceDir = moveSpeed > 0.1f;
        if(faceDir == true)
        {
            if(moveDirection == 1)
            {
                sr.flipX = false;
            }
            if(moveDirection == -1)
            {
                sr.flipX = true;
            }
        }
    }

    private void Attack_Player()
    {
        //�õ���Һ͵���֮���x���ֵ�ľ���ֵ
        float PToE_distence = Vector2.Distance(transform.position, player.transform.position);
        //�õ�����ڵ��˵��ķ�
        //�������ڵ����ҷ���Ϊtrue ����Ϊfalse
        bool isPinE_Right = true;
        if (transform.position.x - player.transform.position.x < 0)
        {
            isPinE_Right = true;
        }
        if (transform.position.x - player.transform.position.x > 0)
        {
            isPinE_Right = false;
        }

        if (PToE_distence <= findRange && PToE_distence >attackRange)
        {
            if(isPinE_Right == true)
            {
                sr.flipX = false;
                moveDirection = 1;
            }
            if(isPinE_Right == false)
            {
                sr.flipX = true;
                moveDirection = -1;
            }
            Vector2 targetPos = new Vector2(player.transform.position.x, transform.position.y); 
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        if(PToE_distence <= attackRange)
        {
            player.GetComponent<PlayerControl>().Hp -= 20;
        }
    }



}   
