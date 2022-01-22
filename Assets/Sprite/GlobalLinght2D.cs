using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class GlobalLinght2D : MonoBehaviour
{
    Light2D San;//��ȡ�ƹ����
    public float SunTime;//̫�������ʱ��
    public bool isSun=true;//�Ƿ�ִ�н���
    public float WhiteSeep;//���쵽���ϵ��ٶ�
    public float BlackSeep;//���ϵ�������ٶ�
    public float SanGameTime = 120;//��Ϸ���չ��ʱ��
    


    void Start()
    {
        San = GetComponent<Light2D>();
        
    }

    
    void FixedUpdate()
    {
        
        if (SanGameTime <= 0)//��������
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
    void whiteblack()//���쵽����
    {
 
         San.intensity *= WhiteSeep; 
        SunTime -= Time.deltaTime;
        if (SunTime <= 0)
        {
            Debug.Log(string.Format("����", Time.time));
            isSun = false;
            SunTime = 10.0f;
        }
    }
    void blackwhite()//���ϵ�����
    {
        San.intensity *= BlackSeep;
        SunTime -= Time.deltaTime;
        if (SunTime <= 0)
        {
            Debug.Log(string.Format("����", Time.time));
            isSun = true;
            SunTime = 10.0f;
        }
    }
    
}
