using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    Light2D PlayerSan;//��ȡ�ƹ����
    private float wai = 0.001f;//��ķ�Χ��ֵ
    private float qiang = 0.0001f;//���ǿ�ȱ仯��ֵ

    public bool isDebuff;
    void Start()
    {
        PlayerSan = GetComponent<Light2D>();
        
    }

    
    void FixedUpdate()
    {

        
        if (PlayerSan.pointLightOuterRadius>=1)
        {
            PlayerSan.pointLightOuterRadius -= wai;
        }
        if (PlayerSan.intensity>=0.1f)
        {
            PlayerSan.intensity -= qiang;
        }
        
        
    }

}
