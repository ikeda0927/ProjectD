using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    //残り回数
    private readonly int REST_MAX = 5;
    private static int rest;
    private static int score = 0;
    private static readonly int[] ARRAY = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private static int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private const int ADD_SCORE_MAX = 10;
    private const int ADD_SCORE_MIN = 0;
    private static GameObject balls;
    private static GameObject ball;
    private static bool endJudge = false;
    private static bool isFoul = false;
    private static bool shotJudge = false;
    private static GameObject cue;
    private static GameObject UI_rest;
    private static GameObject UI_score;
    private static Text UI_rest_text;
    private static Text UI_score_text;
    private static bool reset;
    private static Vector3[] posisions = new Vector3[9];
    private static Vector3 cuePosition;
    private static Quaternion cueRotation;

    //test
    bool keyJudge = true;
    public string str = "12";

    void Start()
    {
        rest = REST_MAX;
        balls = GameObject.Find("Balls");
        ball = GameObject.Find("Ball");
        cue = GameObject.Find("Cue");
        UI_rest = GameObject.Find("Rest");
        UI_score = GameObject.Find("Score");
        UI_rest_text = UI_rest.GetComponentInChildren<Text>();
        UI_score_text = UI_score.GetComponentInChildren<Text>();
        for (int i = 0; i < balls.transform.childCount; i++)
        {
            posisions[i] = balls.transform.GetChild(i).gameObject.transform.position;
        }
        cuePosition = cue.transform.position;
        cueRotation = cue.transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ゲームにルールを追加

        if (rest <= 0)
        {
            endJudge = true;
        }

        if (endJudge)
        {
            //Destroy(cue.GetComponent<BilliartdCue>());
            cue.GetComponent<BilliartdCue>().enabled = false;
        }

        //ファールになるのは
        //・手球(白い球)が最初に触れた球が台上の球のうち一番数字の小さい球ではなかった場合
        //・手球がポケットに落ちた時
        //ファール時は残り回数は減らない。
        if (isFoul)
        {
            Hole.UnsetHoleIsTrigger();
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.transform.position = new Vector3(0, 5, -4);
            ball.GetComponent<Rigidbody>().isKinematic = false;
            isFoul = false;
        }

        if (rest != REST_MAX)
        {
            //残り回数の表示
            UI_rest_text.text = "R : " + rest;
            //スコアの表示
            UI_score_text.text = "S : " + score;
        }

        //リセット
        if (reset)
        {
            endJudge = false;
            cue.GetComponent<BilliartdCue>().enabled = true;
            Hole.UnsetHoleIsTrigger();
            reset = false;
            array = ARRAY;
            score = 0;
            rest = REST_MAX;
            UI_rest_text.text = "Rest";
            UI_score_text.text = "Score";
            BilliardImage.ResetBallImage();
            int childCount = balls.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                balls.transform.GetChild(i).gameObject.SetActive(true);
                balls.transform.GetChild(i).gameObject.transform.position = posisions[i];
            }
            cue.transform.position = cuePosition;
            cue.transform.rotation = cueRotation;
            BiliardBall.SetReset(true);
        }

        //    //動作確認用

        if (Input.GetKey(KeyCode.S))
        {
            if (keyJudge)
            {
                keyJudge = false;
                AddScore(str);
                AddScore(str);
            }
        }
        else if (Input.GetKey(KeyCode.R))
        {
            if (keyJudge)
            {
                keyJudge = false;
                Debug.Log(score);
            }
        }
        else if (Input.GetKey(KeyCode.T))
        {
            if (keyJudge)
            {
                keyJudge = false;
                //foreach (int i in array)
                //{
                //    Debug.Log("Array : " + i);
                //}
                Debug.Log("Least Number is " + GetLeastNumber());
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (keyJudge)
            {
                keyJudge = false;
                int[] a = GetBalls();
                int i = 1;
                foreach (int temp in a)
                {
                    if (temp == 1)
                    {
                        Debug.Log("Ball:" + i);
                    }
                    i++;
                }
            }
        }
        else
        {
            keyJudge = true;
        }
    }

    //ファール時に呼び出して
    public static void SetIsFoul()
    {
        isFoul = true;
    }

    //ゲームの終了判定
    //ゲームが続いている場合は偽
    //ゲームが終了した場合は真
    public static bool GetEndJudge()
    {
        return endJudge;
    }

    //残り回数の取得ができる。
    public static int GetRest()
    {
        return rest;
    }

    public static bool GetShotJudge()
    {
        return shotJudge;
    }
    public static void SetShotJudge(bool b)
    {
        shotJudge = b;
    }

    //スコアの取得
    public static int GetScore()
    {
        return score;
    }

    public static bool GetReset()
    {
        return reset;
    }

    public static void SetReset(bool b)
    {
        reset = b;
        BiliardBall.SetReset(b);
    }

    //残り回数の変更
    //CueのOnCollisionEnterの中から呼び出してね
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

    //現在残っている球の中でもっとも低い数字を返す
    public static int GetLeastNumber()
    {
        int i = 0;
        int[] tempArray = GetBalls();
        for (int j = 0; j < tempArray.Length; j++)
        {
            if (tempArray[j] == 1)
            {
                return j + 1;
            }
        }
        return i;
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
            if (balls.transform.GetChild(i).gameObject.activeSelf)
            {
                a[i] = 1;
            }
            //a[int.Parse(balls.transform.GetChild(i).transform.tag) - 1] = 1;
        }
        return a;
    }
}
