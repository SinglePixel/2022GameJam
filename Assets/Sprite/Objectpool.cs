using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpool : MonoBehaviour
{
    public static Objectpool instance;//设置单例模式

public GameObject shandowPrefab;//获取残影预制体

public int shandowCount;//对象池中生成数量

public float BrightGameTime = 120;//游戏有日光的时间
public bool isFinish =true;

private Queue<GameObject> availableObjects = new Queue<GameObject>();//获取新建队列(残影)

void Awake()
{
    instance = this;
    //初始化对象池
    FillPool();

}
void FixedUpdate()
    {
        if (BrightGameTime<=0)
        {
            isFinish = false;
            return;
        }
        BrightGameTime -= Time.deltaTime;
    }

public void FillPool()//初始化对象池的方法
{
    for (int i = 0; i < shandowCount; i++)
    {
        var newShadow = Instantiate(shandowPrefab);
        newShadow.transform.SetParent(transform);//生成的物体在子级下面
                                                 //取消启用、也叫返回对象
        ReturnPool(newShadow);
    }
}

public void ReturnPool(GameObject gameobject)//残影返回对象池方法
{
    gameobject.SetActive(false);
    availableObjects.Enqueue(gameobject);

}

public GameObject GetFormPool()//残影这边拿一个对象
{
    if (availableObjects.Count == 0)//如果对象池不够等于零时
    {
        FillPool();
    }
    var outShadow = availableObjects.Dequeue();
    outShadow.SetActive(true);
    return outShadow;
}
    //结束代码
}