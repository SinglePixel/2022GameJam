using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    Light2D PlayerSan;//获取灯光组件
    private float wai = 0.001f;//光的范围差值
    private float qiang = 0.0001f;//光的强度变化差值

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
