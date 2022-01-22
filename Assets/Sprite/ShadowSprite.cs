using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player; //玩家位置

    private SpriteRenderer thisSprite;//自己精灵图片
    private SpriteRenderer playerSprite;//玩家精灵图片
    private Color color;//残影颜色

    [Header("时间控制参数")]
    public float activeTime;//残影显示时间
    public float actoveStart;//开始显示时间

    [Header("不透明度控制")]
    private float alpha;//不透明度
    public float alphaSet;//初始值
    public float alphaMultiplier;//变透明速度

    private void OnEnable()//当被启用的时候
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;//获取玩家标签，然后找到位置
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
            //返还对象池
            Objectpool.instance.ReturnPool(this.gameObject);
        }
        //Debug.Log("偶系Debug.Log输出得");
    }
}
