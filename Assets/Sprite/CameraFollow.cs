using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTarget;//��ȡ���λ��
    public float smoothing;//���������Ҳ�ֵ


    void LateUpdate()
    {
        if (PlayerTarget !=null)
        {
            if (transform.position !=PlayerTarget.position)
            {
                Vector2 targetPos = PlayerTarget.position;
                transform.position = Vector2.Lerp(transform.position,targetPos,smoothing);//����������
            }
        }
    }
    void Update()
    {
        
    }
}
