using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardImage : MonoBehaviour
{
    // Start is called before the first frame update
    private const int ballSum = 9;
    private static GameObject[] images = new GameObject[ballSum];
    bool keyJudge = false;
    void Start()
    {
        for (int i = 0; i < ballSum; i++)
        {
            string s = "RawImage" + (i + 1).ToString();
            images[i] = GameObject.Find(s);
        }
    }

    //Billiardの数字を引数として渡すとそのボールが消えます。
    public static void DestroyBallImage(int num)
    {
        Destroy(images[num + 1]);
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey("1"))
    //    {
    //        if (keyJudge)
    //        {
    //            keyJudge = false;
    //            Destroy(images[0]);
    //        }
    //    }
    //    else if (Input.GetKey("2"))
    //    {
    //        if (keyJudge)
    //        {
    //            keyJudge = false;
    //            Destroy(images[1]);
    //        }
    //    }
    //    else if (Input.GetKey("3"))
    //    {
    //        if (keyJudge)
    //        {
    //            keyJudge = false;
    //            Destroy(images[2]);
    //        }
    //    }
    //    else if (Input.GetKey("4"))
    //    {
    //        if (keyJudge)
    //        {
    //            keyJudge = false;
    //            Destroy(images[3]);
    //        }
    //    }
    //    else if (Input.GetKey("5"))
    //    {
    //        if (keyJudge)
    //        {
    //            keyJudge = false;
    //            Destroy(images[4]);
    //        }
    //    }
    //    else if (Input.GetKey("6"))
    //    {
    //        if (keyJudge)
    //        {
    //            keyJudge = false;
    //            Destroy(images[5]);
    //        }
    //    }
    //    else if (Input.GetKey("7"))
    //    {
    //        if (keyJudge)
    //        {
    //            keyJudge = false;
    //            Destroy(images[6]);
    //        }
    //    }
    //    else if (Input.GetKey("8"))
    //    {
    //        if (keyJudge)
    //        {
    //            keyJudge = false;
    //            Destroy(images[7]);
    //        }
    //    }
    //    else if (Input.GetKey("9"))
    //    {
    //        if (keyJudge)
    //        {
    //            keyJudge = false;
    //            Destroy(images[8]);
    //        }
    //    }
    //    else
    //    {
    //        keyJudge = true;
    //    }
    //}
}
