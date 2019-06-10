using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    // Start is called before the first frame update
    static bool keyJudge = true;
    float WEIGHT = .2f;
    GameObject bottom;
    GameObject top;
    GameObject pusher;
    GameObject ball;
    GameObject spring;
    float bottomSize;
    float topSize;
    float pusherSize;
    float topPositionWeight = 5f;

    void Start()
    {
        bottom = GameObject.FindWithTag("Bottom");
        top = GameObject.FindWithTag("Top");
        pusher = GameObject.FindWithTag("Pusher");
        ball = GameObject.FindWithTag("Ball");
        spring = GameObject.FindWithTag("Spring");
        bottomSize = spring.transform.localScale.y * bottom.transform.localScale.y;
        topSize = spring.transform.localScale.y * top.transform.localScale.y;
        pusherSize = spring.transform.localScale.y * pusher.transform.localScale.y;
        //Debug.Log("bottomSize:" + bottomSize + " topSize:" + topSize + " pusherSize:" + pusherSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (keyJudge)
            {
                //keyJudge = false;
                if (pusher.transform.localPosition.y > bottomSize * 1.5 + topSize + pusherSize)
                {
                    gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - WEIGHT, gameObject.transform.localPosition.z);
                }
            }
        }
        else if (Input.GetKey(KeyCode.R))
        {
            if (keyJudge)
            {
                keyJudge = false;
                gameObject.transform.localPosition = new Vector3(0, topPositionWeight + topSize * 0.5f, 0);
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponent<BoxCollider>().enabled = true;
                Rigidbody r = gameObject.AddComponent<Rigidbody>();
                r.isKinematic = true;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (keyJudge)
            {
                keyJudge = false;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                Destroy(gameObject.GetComponent<Rigidbody>());
            }
        }
        else
        {
            keyJudge = true;
        }
    }
}
