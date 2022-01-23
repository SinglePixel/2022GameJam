using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public GameObject Start_Button;//��ʼ��Ϸ��ť
    public GameObject Set_button;//���ð�ť
    public GameObject Logo;//logoͼƬ
    public GameObject Exit_game_button;//�˳���Ϸ��ť
    public GameObject Exit_Game_Canvas;//�˳���Ϸ����Ļ���
    public GameObject Confirm_button;//ȷ����ť
    public GameObject Cancel_button;//ȡ����ť
    public GameObject ���ý����ȷ����ť;
    public GameObject ���ý����ȡ����ť;
    public GameObject ���ý����Logo;
    public GameObject ���ý���Ļ���;
    public GameObject ֡��30;
    public GameObject ֡��60;
    public GameObject ֡��120;
    public GameObject ���ֻ�����;
    public GameObject ��Ч������;
    public GameObject ��Ļ��;


    public void Start_Button_To_Enlarge()//��ʼ��ť�Ŵ��¼�
    {
        Start_Button.GetComponent<RectTransform>().DOScale(new Vector2(1.2f, 1.2f), 0.3f);
    }
    public void Start_button_shrinks()//��ʼ��ť��С�¼�
    {
        Start_Button.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void Set_button_to_enlarge()//���ð�ť�Ŵ��¼�
    {
        Set_button.GetComponent<RectTransform>().DOScale(new Vector2(1.2f, 1.2f), 0.3f);
    }
    public void Set_button_to_shrink()//���ð�ť��С�¼�
    {
        Set_button.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void Exit_game_button_enlarge()//�˳���Ϸ��ť�Ŵ��¼�
    {
        Exit_game_button.GetComponent<RectTransform>().DOScale(new Vector2(1.2f, 1.2f), 0.3f);
    }
    public void Exit_game_button_shrinks()//�˳���Ϸ��ť��С�¼�
    {
        Exit_game_button.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void Exit_button_mouse_up()//�˳���Ϸ��ť���̧��
    {
        Exit_Game_Canvas.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.5f);
    }
    public void Logo_enlarge()//Logo�Ŵ��¼�
    {
        Logo.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void Logo_shrinks()//Logo��С�¼�
    {
        Logo.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.5f);

    }
    public void Confirm_button_enlarge()//ȷ����ť�Ŵ��¼�
    {
        Confirm_button.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void Confirm_button_shrinks()//ȷ����ť��С�¼�
    {
        Confirm_button.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void Confirm_button_mouse_up()//ȷ����ť���̧���¼�
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    public void Cancel_button_enlarge()//ȡ����ť�Ŵ��¼�
    {
        Cancel_button.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void Cancel_button_shrinks()//ȡ����ť��С�¼�
    {
        Cancel_button.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void Cancel_button_mouse_up()//ȡ����ť���̧���¼�
    {
        Exit_Game_Canvas.GetComponent<RectTransform>().DOScale(new Vector2(0f, 0f), 0.3f);
    }
    public void ���ý���ȷ����ť�Ŵ�()
    {
        ���ý����ȷ����ť.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void ���ý���ȷ����ť��С()
    {
        ���ý����ȷ����ť.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void ���ý���ȷ����ť���̧��()
    {
        int �������� = 10;//���Ϊ10,��СΪ0
        int ��Ч���� = 10;
        if (֡��30.GetComponent<Toggle>().isOn){
            Application.targetFrameRate = 30;
            Debug.Log("30");
        }
        else
        {
            if (֡��60.GetComponent<Toggle>().isOn)
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
        �������� = (int)���ֻ�����.GetComponent<Slider>().value;
        ��Ч���� = (int)��Ч������.GetComponent<Slider>().value;
        ���ý���Ļ���.GetComponent<RectTransform>().DOScale(new Vector2(0f, 0f), 0.3f);
        Debug.Log(��������);
        Debug.Log(��Ч����);

    }
    public void ���ý���ȡ����ť�Ŵ�()
    {
        ���ý����ȡ����ť.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void ���ý���ȡ����ť��С()
    {
        ���ý����ȡ����ť.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void ���ý���logo�Ŵ�()
    {
        ���ý����Logo.GetComponent<RectTransform>().DOScale(new Vector2(1.1f, 1.1f), 0.3f);
    }
    public void ���ý���logo��С()
    {
        ���ý����Logo.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void ���ý��滭���Ŵ�()
    {
        ���ý���Ļ���.GetComponent<RectTransform>().DOScale(new Vector2(1f, 1f), 0.3f);
    }
    public void ���ý��滭����С()
    {
        ���ý���Ļ���.GetComponent<RectTransform>().DOScale(new Vector2(0f, 0f), 0.3f);
    }

    public void ��ʼ��Ϸ��ť���̧��()
    {
        ��Ļ��.SetActive(true);
        Tweener tweener=��Ļ��.GetComponent<Image>().DOFade(1, 3);
        tweener.OnComplete(������鳡��);
        
    }
    public void ����logo()
    {
        SceneManager.LoadScene(5);
    }
    void ������鳡��()
    {
        SceneManager.LoadScene(1);
    }
}
