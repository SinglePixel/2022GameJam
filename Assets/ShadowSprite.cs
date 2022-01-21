using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player; //���λ��

    private SpriteRenderer thisSprite;//�Լ�����ͼƬ
    private SpriteRenderer playerSprite;//��Ҿ���ͼƬ
    private Color color;//��Ӱ��ɫ

    [Header("ʱ����Ʋ���")]
    public float activeTime;//��Ӱ��ʾʱ��
    public float actoveStart;//��ʼ��ʾʱ��

    [Header("��͸���ȿ���")]
    private float alpha;//��͸����
    public float alphaSet;//��ʼֵ
    public float alphaMultiplier;//��͸���ٶ�

    private void OnEnable()//�������õ�ʱ��
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;//��ȡ��ұ�ǩ��Ȼ���ҵ�λ��
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        alpha = alphaSet;
        thisSprite.sprite = playerSprite.sprite;
        transform.position = player.position;
        transform.localScale = player.localScale;
        transform.rotation = player.rotation;
        actoveStart = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        alpha = alpha * alphaMultiplier;
        color = new Color(0.5f, 0.5f, 0, alpha);
        thisSprite.color = color;
        if (Time.time >= activeTime + actoveStart)
        {
            //���������
            Objectpool.instance.ReturnPool(this.gameObject);
        }
        //Debug.Log("żϵDebug.Log�����");
    }
}
