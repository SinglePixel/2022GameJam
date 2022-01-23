using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xieshengjiao : MonoBehaviour
{
    [SerializeField]
    [Header("Ҫ���ٵ���")]
    public Transform player; //Ҫ���ٵ��� 

    [SerializeField]
    [Header("�ƶ��ٶ�")]
    private float moveSpeed = 5.0f;//�ƶ��ٶ�

    [SerializeField]
    [Header("ѡ���ٶ�")]
    private float rotateSpeed = 5.0f;//ѡ���ٶ�

    [SerializeField]
    [Header("�Լ�")]
    private Transform mytransform;//�Լ�



    void Start()
    {
        //��Ҫ���ٵĶ���Tag ����Ϊ Player
        Transform target = player.transform;

    }


    void Update()
    {
        Debug.DrawLine(player.transform.position, this.transform.position, Color.yellow);


        mytransform.rotation = Quaternion.Slerp(mytransform.rotation, Quaternion.LookRotation(player.position - mytransform.position), rotateSpeed * Time.deltaTime);


        mytransform.position += mytransform.forward * moveSpeed * Time.deltaTime;
    }

}
