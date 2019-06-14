using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiliardBall : MonoBehaviour
{
    private AudioSource sound01;
    private bool startJudge = false;
    private const int WEIGHT = 60;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        sound01 = GetComponent<AudioSource>();
        //startJudge = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (startJudge && (collision.transform.tag == "1" || collision.transform.tag == "2" || collision.transform.tag == "3" || collision.transform.tag == "4" || collision.transform.tag == "5" || collision.transform.tag == "6" || collision.transform.tag == "7" || collision.transform.tag == "8" || collision.transform.tag == "9"))
        {
            Debug.Log("Collision in BilliardBall : " + collision.transform.tag);
            sound01.PlayOneShot(sound01.clip);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!startJudge)
        {
            if (counter < WEIGHT)
            {
                counter++;
            }
            else
            {
                startJudge = true;
            }
        }
    }
}
