using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public GameObject Start_Button;//开始游戏按钮
    public GameObject Set_button;//设置按钮
    public GameObject Logo;//logo图片
    public GameObject Exit_game_button;//退出游戏按钮
    public GameObject Exit_Game_Canvas;//退出游戏界面的画布
    public GameObject Confirm_button;//确定按钮
    public GameObject Cancel_button;//取消按钮
    public GameObject 设置界面的确定按钮;
    public GameObject 设置界面的取消按钮;
    public GameObject 设置界面的Logo;
    public GameObject 设置界面的画布;
    public GameObject 帧率30;
    public GameObject 帧率60;
    public GameObject 帧率120;
    public GameObject 音乐滑动条;
    public GameObject 音效滑动条;
    public GameObject 黑幕布;


    public void Start_Button_To_Enlarge()//开始按钮放大事件
    {
        Start_Button.GetComponent<RectTransform>().DOScale(new Vector2(1.2f, 1.2f), 0.3f);
    }
    public void Start_button_shrinks()//开始按钮缩小事件
    {
        Start_Button.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void Set_button_to_enlarge()//设置按钮放大事件
    {
        Set_button.GetComponent<RectTransform>().DOScale(new Vector2(1.2f, 1.2f), 0.3f);
    }
    public void Set_button_to_shrink()//设置按钮缩小事件
    {
        Set_button.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void Exit_game_button_enlarge()//退出游戏按钮放大事件
    {
        Exit_game_button.GetComponent<RectTransform>().DOScale(new Vector2(1.2f, 1.2f), 0.3f);
    }
    public void Exit_game_button_shrinks()//退出游戏按钮缩小事件
    {
        Exit_game_button.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void Exit_button_mouse_up()//退出游戏按钮鼠标抬起
    {
        Exit_Game_Canvas.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.5f);
    }
    public void Logo_enlarge()//Logo放大事件
    {
        Logo.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void Logo_shrinks()//Logo缩小事件
    {
        Logo.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.5f);

    }
    public void Confirm_button_enlarge()//确定按钮放大事件
    {
        Confirm_button.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void Confirm_button_shrinks()//确定按钮缩小事件
    {
        Confirm_button.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void Confirm_button_mouse_up()//确定按钮鼠标抬起事件
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    public void Cancel_button_enlarge()//取消按钮放大事件
    {
        Cancel_button.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void Cancel_button_shrinks()//取消按钮缩小事件
    {
        Cancel_button.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void Cancel_button_mouse_up()//取消按钮鼠标抬起事件
    {
        Exit_Game_Canvas.GetComponent<RectTransform>().DOScale(new Vector2(0f, 0f), 0.3f);
    }
    public void 设置界面确定按钮放大()
    {
        设置界面的确定按钮.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void 设置界面确定按钮缩小()
    {
        设置界面的确定按钮.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void 设置界面确定按钮鼠标抬起()
    {
        int 音乐音量 = 10;//最大为10,最小为0
        int 音效音量 = 10;
        if (帧率30.GetComponent<Toggle>().isOn){
            Application.targetFrameRate = 30;
            Debug.Log("30");
        }
        else
        {
            if (帧率60.GetComponent<Toggle>().isOn)
            {
                Application.targetFrameRate = 60;
                Debug.Log("60");
            }
            else
            {
                Application.targetFrameRate = 120;
                Debug.Log("120");
            }
        }
        音乐音量 = (int)音乐滑动条.GetComponent<Slider>().value;
        音效音量 = (int)音效滑动条.GetComponent<Slider>().value;
        设置界面的画布.GetComponent<RectTransform>().DOScale(new Vector2(0f, 0f), 0.3f);
        Debug.Log(音乐音量);
        Debug.Log(音效音量);

    }
    public void 设置界面取消按钮放大()
    {
        设置界面的取消按钮.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void 设置界面取消按钮缩小()
    {
        设置界面的取消按钮.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void 设置界面logo放大()
    {
        设置界面的Logo.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void 设置界面logo缩小()
    {
        设置界面的Logo.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void 设置界面画布放大()
    {
        设置界面的画布.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void 设置界面画布缩小()
    {
        设置界面的画布.GetComponent<RectTransform>().DOScale(new Vector2(0f, 0f), 0.3f);
    }

    public void 开始游戏按钮鼠标抬起()
    {
        黑幕布.SetActive(true);
        Tweener tweener=黑幕布.GetComponent<Image>().DOFade(1, 3);
        tweener.OnComplete(载入剧情场景);
        
    }
    public void 按下logo()
    {
        SceneManager.LoadScene(5);
    }
    void 载入剧情场景()
    {
        SceneManager.LoadScene(1);
    }
}
