using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xieshengjiao : MonoBehaviour
{
    [SerializeField]
    [Header("要跟踪的人")]
    public Transform player; //要跟踪的人 

    [SerializeField]
    [Header("移动速度")]
    private float moveSpeed = 5.0f;//移动速度

    [SerializeField]
    [Header("选择速度")]
    private float rotateSpeed = 5.0f;//选择速度

    [SerializeField]
    [Header("自己")]
    private Transform mytransform;//自己



    void Start()
    {
        //把要跟踪的对象Tag 设置为 Player
        Transform target = player.transform;

    }


    void Update()
    {
        Debug.DrawLine(player.transform.position, this.transform.position, Color.yellow);


        mytransform.rotation = Quaternion.Slerp(mytransform.rotation, Quaternion.LookRotation(player.position - mytransform.position), rotateSpeed * Time.deltaTime);


        mytransform.position += mytransform.forward * moveSpeed * Time.deltaTime;
    }

}
