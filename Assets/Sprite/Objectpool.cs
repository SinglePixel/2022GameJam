using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpool : MonoBehaviour
{
    public static Objectpool instance;//���õ���ģʽ

public GameObject shandowPrefab;//��ȡ��ӰԤ����

public int shandowCount;//���������������

public float BrightGameTime = 120;//��Ϸ���չ��ʱ��
public bool isFinish =true;

private Queue<GameObject> availableObjects = new Queue<GameObject>();//��ȡ�½�����(��Ӱ)

void Awake()
{
    instance = this;
    //��ʼ�������
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

public void FillPool()//��ʼ������صķ���
{
    for (int i = 0; i < shandowCount; i++)
    {
        var newShadow = Instantiate(shandowPrefab);
        newShadow.transform.SetParent(transform);//���ɵ��������Ӽ�����
                                                 //ȡ�����á�Ҳ�з��ض���
        ReturnPool(newShadow);
    }
}

public void ReturnPool(GameObject gameobject)//��Ӱ���ض���ط���
{
    gameobject.SetActive(false);
    availableObjects.Enqueue(gameobject);

}

public GameObject GetFormPool()//��Ӱ�����һ������
{
    if (availableObjects.Count == 0)//�������ز���������ʱ
    {
        FillPool();
    }
    var outShadow = availableObjects.Dequeue();
    outShadow.SetActive(true);
    return outShadow;
}
    //��������
}