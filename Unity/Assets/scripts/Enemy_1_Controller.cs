using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy_1_Controller : MonoBehaviour
{
    //动画对象
    private Animator ani;
    //刚体对象
    private Rigidbody2D rBody;
    //精灵渲染对象
    private SpriteRenderer sr;
    //血量
    public int Hp = 100;
    //玩家对象
    public GameObject player;
    //导航组件
    private NavMeshAgent navMeshAgent;
    //玩家Trigger
    public GameObject trigger1;
    //敌人Trigger
    public GameObject trigger2;
    // 移动速度
    public float moveSpeed = 5f;
    // 移动范围
    public float moveRange = 5f;
    // 敌人初始位置的 X 坐标
    private float startXPos;
    // 记录当前移动方向的变量，1 表示向右，-1 表示向左。
    private int moveDirection = 1;
    //敌人检测玩家的距离
    public float findRange = 10f;
    //敌人攻击玩家的距离
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
        //计算要移动的距离
        float distenceToMove = moveSpeed * Time.deltaTime;

        //移动敌人,并根据移动范围反转移动方向
        transform.position += new Vector3(distenceToMove * moveDirection, 0, 0);
        if (Mathf.Abs(transform.position.x - startXPos) > moveRange / 2)
        {
            moveDirection *= -1;
        }
        Flip();
        Attack_Player();
    }
    //敌人的碰撞:使用碰撞回调方法
    //OnTriggerEnter2D:与敌人产生碰撞

    //翻转动画
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
        //得到玩家和敌人之间的x轴差值的绝对值
        float PToE_distence = Vector2.Distance(transform.position, player.transform.position);
        //得到玩家在敌人的哪方
        //如果玩家在敌人右方则为true 否则为false
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
