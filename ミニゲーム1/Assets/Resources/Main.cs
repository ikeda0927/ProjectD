using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    //残り回数
    private static int rest = 5;
    private static int score = 0;
    private static int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private const int ADD_SCORE_MAX = 10;
    private const int ADD_SCORE_MIN = 0;
    private static GameObject balls;


    //test
    bool keyJudge = true;
    public string str = "12";

    void Start()
    {
        balls = GameObject.Find("Balls");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //動作確認用

        //if (Input.GetKey(KeyCode.S))
        //{
        //    if (keyJudge)
        //    {
        //        keyJudge = false;
        //        AddScore(str);
        //        AddScore(str);
        //    }
        //}
        //else if (Input.GetKey(KeyCode.R))
        //{
        //    if (keyJudge)
        //    {
        //        keyJudge = false;
        //        Debug.Log(score);
        //    }
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    if (keyJudge)
        //    {
        //        keyJudge = false;
        //        int[] a = GetBalls();
        //        int i = 1;
        //        foreach (int temp in a)
        //        {
        //            if (temp == 1)
        //            {
        //                Debug.Log("Ball:" + i);
        //            }
        //            i++;
        //        }
        //    }
        //}
        //else
        //{
        //    keyJudge = true;
        //}
    }

    //残り回数の取得ができる。
    public static int GetRest()
    {
        return rest;
    }

    //スコアの取得
    public static int GetScore()
    {
        return score;
    }

    //残り回数の変更
    public static void SubstructTheRest()
    {
        rest--;
    }

    //スコアの計算
    //ビリヤードの球に加えられたtag(string型の数字)を引数として与えると、スコアが加算される。
    //ちなみに、同じ球のスコアを複数回加算してしまうような動作はしないようにしてある。
    public static void AddScore(string tag)
    {
        try
        {
            int parsedInt = int.Parse(tag);
            score = score + array[(parsedInt > ADD_SCORE_MIN && parsedInt < ADD_SCORE_MAX) ? parsedInt : 0];
            array[(parsedInt > ADD_SCORE_MIN && parsedInt < ADD_SCORE_MAX) ? parsedInt : 0] = 0;
        }
        catch (System.Exception e)
        {
        }
    }

    //現在残っている球を返す。
    //例えば、すべての球が残っている場合
    //a=[1,1,1,1,1,1,1,1,1]
    //
    //2,4,6の球が残っている場合、
    //a=[0,1,0,1,0,1,0,0,0]
    //
    //のような感じになる。
    public static int[] GetBalls()
    {
        int[] a = new int[9];
        int childCount = balls.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            a[int.Parse(balls.transform.GetChild(i).transform.tag) - 1] = 1;
        }
        return a;
    }
}
