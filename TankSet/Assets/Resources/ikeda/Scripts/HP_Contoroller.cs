using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Contoroller : MonoBehaviour
{
    public readonly int HPSum = 10;
    private int HPCounter;
    private GameObject[] lives;
    // Start is called before the first frame update
    void Start()
    {
        HPCounter = HPSum;
        lives = new GameObject[HPSum];
        for (int i = 0; i < HPSum; i++)
        {
            string s = "Life" + i.ToString();
            lives[i] = GameObject.Find(s);
        }
    }

    public void LoseHP(int i)
    {
        if (GetDeadOrAlive())
        {
            if (HPCounter < i)
            {
                for (int k = HPCounter; k >= 0; k--)
                {
                    lives[k].SetActive(false);
                }
                HPCounter = 0;
                //return false;
            }
            else
            {
                for (int k = 0; k < i; k++)
                {
                    //Debug.Log("LoseHP, HPCounter :" + HPCounter.ToString());
                    lives[HPCounter - 1].SetActive(false);
                    HPCounter--;
                }
            }
        }
        //return true;
    }

    public bool GetDeadOrAlive()
    {
        if (HPCounter <= 0)
        {
            return false;
        }
        return true;
    }
    public void Init()
    {
        HPCounter = HPSum;
        for (int i = 0; i < HPSum; i++)
        {
            lives[i].SetActive(true);
        }
    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
