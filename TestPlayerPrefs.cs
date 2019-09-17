using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerPrefs : MonoBehaviour
{

    private int first = 1;
    private int second = 0;
    private int third = 0;
    private int fourth = 0;

    GameObject stage1;
    GameObject stage2;
    GameObject stage3;
    GameObject stage4;

    // Start is called before the first frame update
    void Start()
    {
        second = PlayerPrefs.GetInt("second");
        third = PlayerPrefs.GetInt("third");
        fourth = PlayerPrefs.GetInt("fourth");

        stage1 = GameObject.Find("Stage1Button");

        stage2 = GameObject.Find("Stage2Button");
        if (second != 1)
        {
            stage2.SetActive(false);
        }
        stage3 = GameObject.Find("Stage3Button");
        if (third != 1)
        {
            stage3.SetActive(false);
        }
        stage4 = GameObject.Find("Stage4Button");
        if (fourth != 1)
        {
            stage4.SetActive(false);
        }
    }

    public void setSecond()
    {
        PlayerPrefs.SetInt("second", 1);
    }

    public void setThird()
    {
        PlayerPrefs.SetInt("third", 1);
    }

    public void setFourth()
    {
        PlayerPrefs.SetInt("fourth", 1);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("second", 0);
        PlayerPrefs.SetInt("third", 0);
        PlayerPrefs.SetInt("fourth", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
