using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    Light2D PlayerSan;//��ȡ�ƹ����
    void Start()
    {
        PlayerSan = GetComponent<Light2D>();
    }

    
    void FixedUpdate()
    {
        if (PlayerSan.pointLightOuterRadius>=1)
        {
            PlayerSan.pointLightOuterRadius -= 0.001f;
        }
        if (PlayerSan.intensity>=0.1f)
        {
            PlayerSan.intensity -= 0.0001f;
        }
        
        
    }
}
