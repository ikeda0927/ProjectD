using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    bool keyJudge = true;
    static Rigidbody rigidbody;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.O))
        //{
        //    if (keyJudge)
        //    {
        //        keyJudge = false;
        //        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //        transform.position = new Vector3(Random.Range(-100f, 100f), 4, Random.Range(-100f, 100f));
        //        transform.rotation = Quaternion.Euler(0, 0, 0);
        //        gameObject.GetComponent<Rigidbody>().isKinematic = false;

        //    }
        //}
        //else
        //{
        //    keyJudge = true;
        //}
        if (transform.position.y <= 1.5)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = new Vector3(Random.Range(-100f, 100f), 4, Random.Range(-100f, 100f));
            transform.rotation = Quaternion.Euler(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public static void SetKinematic(bool b)
    {
        rigidbody.isKinematic = b;
    }
}
