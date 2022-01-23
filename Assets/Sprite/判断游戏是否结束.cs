using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 判断游戏是否结束 : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Objectpool.instance.isFinish == false)
        {
            SceneManager.LoadScene(3);
        }
    }
}
