using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
public class 游戏结束脚本 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject 重新开始;
    public GameObject 黑幕布;
    void Start()
    {
        黑幕布变黑();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void 重新开始按钮放大()
    {
        重新开始.GetComponent<RectTransform>().DOScale(new Vector2(1.2f, 1.2f), 0.3f);
    }
    public void 重新开始按钮缩小()
    {
        重新开始.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
   public void 重新开始按钮按下()
    {
        SceneManager.LoadScene(0);
    }
    void 黑幕布变黑()
    {
        黑幕布.SetActive(true);
        
        Tweener tweener = 黑幕布.GetComponent<Image>().DOFade(0, 3);
        tweener.OnComplete(隐藏黑幕);
    }
    void 隐藏黑幕()
    {
        黑幕布.SetActive(false);
    }
}

