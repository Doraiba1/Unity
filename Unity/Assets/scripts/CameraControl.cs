using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //����Ŀ��
    public Transform target;
    //����������������С���ֵ
    public float minX;
    public float maxX;
    // Start is called before the first frame update
    //��ʼִ��һ��
    void Start()
    {

    }

    // Update is called once per frame
    //ÿִ֡��һ��
    void Update()
    {
        //��һ���м���������������λ��
        //����Vector
        Vector3 pos = transform.position;//�ű����ض���
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
