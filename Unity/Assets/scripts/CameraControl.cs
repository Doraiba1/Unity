using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //跟踪目标
    public Transform target;
    //定义摄像机跟随的最小最大值
    public float minX;
    public float maxX;
    // Start is called before the first frame update
    //开始执行一次
    void Start()
    {

    }

    // Update is called once per frame
    //每帧执行一次
    void Update()
    {
        //用一个中间变量来储存摄像机位置
        //向量Vector
        Vector3 pos = transform.position;//脚本挂载对象
        pos.x = target.position.x;
        if (pos.x < minX)
        {
            pos.x = minX;
        }
        if (pos.x > maxX)
        {
            pos.x = maxX;
        }
        transform.position = pos;
    }
}
