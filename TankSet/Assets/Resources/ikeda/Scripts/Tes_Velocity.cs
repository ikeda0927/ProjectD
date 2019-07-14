using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tes_Velocity : MonoBehaviour
{
    Text text;
    GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Text_Velocity").GetComponent<Text>();
        tank = GameObject.Find("Tank");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Velocity : " + tank.GetComponent<Tank>().GetVelocity().ToString();
    }
}
