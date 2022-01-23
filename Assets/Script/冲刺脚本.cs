using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

	public partial class 冲刺脚本 : MonoBehaviour
	{
    public static 冲刺脚本 instance;
    public int 冲刺技能CD = 0;
    //public bool 是否开启冲刺技能 = false;
    public GameObject 冲刺按钮文本;
    public GameObject 冲刺按钮;
    public GameObject 倒计时;
    private int 时间=120;
   // public bool 是否已经开启技能 = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(倒计时120());
    }
    IEnumerator 倒计时120()
    {
        while (时间 >= 0)
        {
            倒计时.GetComponent<Text>().text ="剩余时间：" +时间.ToString();
            yield return new WaitForSeconds(1);
            时间--;
            if (时间 == 0)
            {
                Objectpool.instance.isFinish = false;
            }
        }
        //是否已经开启技能 = false;
    }

    private void Update()
    {
        if (冲刺技能CD == 0)
        {
            冲刺按钮文本.GetComponent<Text>().text = "按J使用冲刺技能";
        }
        else if (冲刺技能CD == 2)
        {
            冲刺按钮文本.GetComponent<Text>().text = "技能冷却中.";

        }
        else
        {
            if (冲刺技能CD < 0 || 冲刺技能CD > 2)
            {
                冲刺技能CD = 0;
            }
        }
    }
    public void 冲刺技能()
	{
            冲刺技能CD = 2;
            StartCoroutine(Time());
	}
    IEnumerator Time()
    {
        while (冲刺技能CD >= 0)
        {
            //冲刺按钮文本.GetComponent<Text>().text = 冲刺技能CD.ToString();
           // 是否已经开启技能 = true;
            yield return new WaitForSeconds(1);
            Debug.Log("技能CD" + 冲刺技能CD);
            冲刺技能CD--;
        }
        //是否已经开启技能 = false;
    }


}
