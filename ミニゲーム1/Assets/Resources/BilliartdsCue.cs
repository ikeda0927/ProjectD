using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliartdsCue : MonoBehaviour
{
    // Start is called before the first frame update
    bool keyJudge = true;
    bool shot = false;
    int shotCounter = 0;
    const int shotWeight = 40;
    const float WEIGHT = 0.2f;
    public float force = 250f;
    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball")
        {
            Debug.Log("Collision");
            //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (keyJudge)
            {
                keyJudge = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                //gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, force, 0), ForceMode.Impulse);
                //gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * force, ForceMode.Impulse);
                //Debug.Log("Mathf.Cos(gameObject.transform.localRotation.x * Mathf.Rad2Deg):" + Mathf.Cos(gameObject.transform.localRotation.x * Mathf.Rad2Deg) + "¥ngameObject.transform.localRotation.x * Mathf.Rad2Deg:" + gameObject.transform.localRotation.x * Mathf.Rad2Deg + "");
                //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Sin(gameObject.transform.localRotation.x * Mathf.Rad2Deg) * force, 0, Mathf.Cos(gameObject.transform.localRotation.z * Mathf.Rad2Deg) * force), ForceMode.Impulse);
                gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Mathf.Sin(gameObject.transform.localRotation.x * Mathf.Deg2Rad) * force, Mathf.Cos(gameObject.transform.localRotation.y * Mathf.Deg2Rad) * force, 0), ForceMode.Impulse);
                //keyJudge = false;
                //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 5));
                //shot = true;
            }
        }
        else
        {
            keyJudge = true;
        }
        //if (shot)
        //{
        //    keyJudge = false;
        //    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        //    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 10), ForceMode.Impulse);
        //    if (shotCounter < shotWeight / 2)
        //    {
        //        //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 10), ForceMode.Impulse);
        //        //gameObject.GetComponent<Rigidbody>().position = new Vector3(gameObject.GetComponent<Rigidbody>().position.x, gameObject.GetComponent<Rigidbody>().position.y, gameObject.GetComponent<Rigidbody>().position.z + WEIGHT);
        //        //gameObject.GetComponent<Rigidbody>().position = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z + WEIGHT);
        //        shotCounter++;
        //    }
        //    else if (shotCounter < shotWeight)
        //    {
        //        //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -5), ForceMode.Force);
        //        //gameObject.GetComponent<Rigidbody>().position = new Vector3(gameObject.GetComponent<Rigidbody>().position.x, gameObject.GetComponent<Rigidbody>().position.y, gameObject.GetComponent<Rigidbody>().position.z - WEIGHT);
        //        //gameObject.GetComponent<Rigidbody>().position = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z - WEIGHT);
        //        shotCounter++;
        //    }
        //    else
        //    {
        //        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        //        shotCounter = 0;
        //        keyJudge = true;
        //        shot = false;
        //    }
        //}
    }
}
