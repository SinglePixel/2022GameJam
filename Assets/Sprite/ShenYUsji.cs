using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShenYUsji : MonoBehaviour
{
    public Slider m_MyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_MyText.value = Objectpool.instance.BrightGameTime;
    }
}
