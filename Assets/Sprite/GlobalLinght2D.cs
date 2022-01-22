using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class GlobalLinght2D : MonoBehaviour
{
    Light2D San;//获取灯光组件
    public float SunTime;//太阳交替的时间
    public bool isSun=true;//是否执行交替
    public float WhiteSeep;//白天到晚上的速度
    public float BlackSeep;//晚上到白天的速度
    public float SanGameTime = 120;//游戏有日光的时间
    


    void Start()
    {
        San = GetComponent<Light2D>();
        
    }

    
    void FixedUpdate()
    {
        
        if (SanGameTime <= 0)//结束代码
        {
            San.intensity *= 0.9f;
            return;
        }
        SanGameTime -= Time.deltaTime;

        if (isSun)
        {
            whiteblack();
        }
        if (!isSun)
        {
            blackwhite();
        }


        
    }
    void whiteblack()//白天到晚上
    {
 
         San.intensity *= WhiteSeep; 
        SunTime -= Time.deltaTime;
        if (SunTime <= 0)
        {
            Debug.Log(string.Format("白天", Time.time));
            isSun = false;
            SunTime = 10.0f;
        }
    }
    void blackwhite()//晚上到白天
    {
        San.intensity *= BlackSeep;
        SunTime -= Time.deltaTime;
        if (SunTime <= 0)
        {
            Debug.Log(string.Format("晚上", Time.time));
            isSun = true;
            SunTime = 10.0f;
        }
    }
    
}
