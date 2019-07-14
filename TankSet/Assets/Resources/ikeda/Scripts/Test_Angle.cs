using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Angle : MonoBehaviour
{
    static Text text;
    GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Text_Angle").GetComponent<Text>();
        tank = GameObject.Find("Tank");
    }

    // Update is called once per frame
    //void Update()
    //{
    //    text.text = tank.GetComponent<Tank>().GetAngle().ToString();
    //}
    public static void SetAngle(string s)
    {
        text.text = "Angle : " + s;
    }

}
