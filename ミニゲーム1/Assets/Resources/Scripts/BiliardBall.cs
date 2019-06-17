using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiliardBall : MonoBehaviour
{
    private AudioSource sound01;
    private static bool startJudge = false;
    private const int WEIGHT = 60;
    private int counter = 0;
    private int x_limit = 8;
    private int z_limit = 10;
    private Vector3 originallyPosition;
    private Quaternion originallyRotation;
    private static bool reset;
    // Start is called before the first frame update
    void Start()
    {
        sound01 = GetComponent<AudioSource>();
        //startJudge = true;
        originallyPosition = gameObject.transform.position;
        originallyRotation = gameObject.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (startJudge && (collision.transform.tag == "Ball" || collision.transform.tag == "Cue" || collision.transform.tag == "1" || collision.transform.tag == "2" || collision.transform.tag == "3" || collision.transform.tag == "4" || collision.transform.tag == "5" || collision.transform.tag == "6" || collision.transform.tag == "7" || collision.transform.tag == "8" || collision.transform.tag == "9"))
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
                reset = false;
            }
        }
        //ビリヤードの台上にいるかどうか
        if (reset || gameObject.transform.position.x < x_limit * -1 || gameObject.transform.position.x > x_limit + 1 || gameObject.transform.position.z < z_limit * -1 || gameObject.transform.position.z > z_limit + 1)
        {
            //gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            if (reset)
            {
                gameObject.transform.position = new Vector3(originallyPosition.x, originallyPosition.y + 1, originallyPosition.z);
            }
            else
            {
                gameObject.transform.position = new Vector3(originallyPosition.x, originallyPosition.y, originallyPosition.z);
            }
            gameObject.transform.rotation = originallyRotation;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            if (!startJudge)
            {
                startJudge = false;
            }
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public static void SetReset(bool b)
    {
        reset = b;
    }
}
