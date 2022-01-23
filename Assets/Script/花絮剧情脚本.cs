using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class 花絮剧情脚本 : MonoBehaviour
{
    public GameObject 黑幕布;
    public GameObject 文本;
    public List<string> 列表;
    public int 序号=0;
    void Start()
    {
        黑幕布变黑1();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            黑幕布变黑2();
        }
    }
    void 黑幕布变黑1()
    {
        黑幕布.SetActive(true);
        Tweener tweener = 黑幕布.GetComponent<Image>().DOFade(0, 3);
        tweener.OnComplete(文本动画);
    }
    void 黑幕布变黑2()
    {
        黑幕布.SetActive(true);
        Tweener tweener = 黑幕布.GetComponent<Image>().DOFade(1, 3);
        tweener.OnComplete(载入游戏场景);
    }
    void 文本动画()
    {
        序号++;
        if (序号 == 9)
        {
            黑幕布变黑2();
        }
        else
        {
            // 文本.GetComponent<>
            文本.GetComponent<Text>().text = "";
            Tweener tweener= 文本.GetComponent<Text>().DOText(列表[序号], 5);
            tweener.OnComplete(文本动画);
        }
    }
    void 载入游戏场景()
    {
        SceneManager.LoadScene(0);
    }
}
