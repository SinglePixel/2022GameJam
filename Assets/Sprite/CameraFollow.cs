using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTarget;//获取玩家位置
    public float smoothing;//相机跟随玩家差值


    void LateUpdate()
    {
        if (PlayerTarget !=null)
        {
            if (transform.position !=PlayerTarget.position)
            {
                Vector2 targetPos = PlayerTarget.position;
                transform.position = Vector2.Lerp(transform.position,targetPos,smoothing);//相机跟随玩家
            }
        }
    }
    void Update()
    {
        
    }
}
