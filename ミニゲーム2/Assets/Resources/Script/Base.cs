using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    //// Start is called before the first frame update

    GameObject cate1;
    GameObject cate2;
    Rigidbody rCate1;
    Rigidbody rCate2;
    Vector3 forceF;
    Vector3 forceB;
    public float forceWeight = 17f;

    float radius = 5f;
    public float force = 5000f;
    GameObject bomb;
    GameObject ball;
    GameObject bulletPrefab;
    GameObject battery;
    bool keyJudge = true;
    bool keyJudge2 = true;
    bool bulletJudge = true;
    const int BULLETWEIGHT = 20;
    int bulletWeight;
    const float eulerWeight = 1f;
    //bool firstGetIsMove = true;

    bool isMove;
    bool isHorizontal;
    GameObject body;
    AudioSource bomb3;
    void Start()
    {
        bomb3 = GetComponent<AudioSource>();
        cate1 = GameObject.Find("Caterpiller1");
        cate2 = GameObject.Find("Caterpiller2");
        rCate1 = cate1.GetComponent<Rigidbody>();
        rCate2 = cate2.GetComponent<Rigidbody>();
        forceF = new Vector3(0, forceWeight, 0);
        forceB = new Vector3(0, -forceWeight, 0);


        bulletPrefab = Resources.Load("Bullet") as GameObject;
        battery = GameObject.Find("Battery");
        bomb = GameObject.FindWithTag("Bomb");
        ball = Instantiate(bulletPrefab, battery.transform.position, Quaternion.identity);

        body = GameObject.Find("Body");
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.M))
        //{
        //    if (keyJudge)
        //    {
        //        isMove = !isMove;
        //        keyJudge = false;
        //    }
        //}
        //else if (!keyJudge)
        //{
        //    keyJudge = true;
        //}

        if (Input.GetKey(KeyCode.A))
        {
            if (keyJudge2 && bulletJudge)
            {
                keyJudge2 = false;
                //ball = Instantiate(bulletPrefab, battery.transform.position, Quaternion.identity);
                Launch();
                bulletJudge = false;
            }
            bomb3.Play();
        }
        else
        {
            if (!bulletJudge && bulletWeight < BULLETWEIGHT)
            {
                bulletWeight++;
            }
            else if (!bulletJudge)
            {
                ball = Instantiate(bulletPrefab, battery.transform.position, Quaternion.identity);
                Debug.Log("Bullet Charged.");
                bulletJudge = true;
                bulletWeight = 0;
            }
            keyJudge2 = true;
        }

        if (Input.GetKey(KeyCode.V))
        {
            if (isMove)
            {
                rCate1.AddRelativeForce(forceF, ForceMode.Force);
                rCate2.AddRelativeForce(forceB, ForceMode.Force);
            }
            else
            {
                ToMoveable();
            }
        }
        else if (Input.GetKey(KeyCode.N))
        {
            if (isMove)
            {
                rCate1.AddRelativeForce(forceB, ForceMode.Force);
                rCate2.AddRelativeForce(forceF, ForceMode.Force);
            }
            else
            {
                ToMoveable();
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if (isMove)
            {
                rCate1.AddRelativeForce(forceF, ForceMode.Force);
                rCate2.AddRelativeForce(forceF, ForceMode.Force);
            }
            else
            {
                ToMoveable();
            }
        }
        else if (Input.GetKey(KeyCode.B))
        {
            if (isMove)
            {
                rCate1.AddRelativeForce(forceB, ForceMode.Force);
                rCate2.AddRelativeForce(forceB, ForceMode.Force);
            }
            else
            {
                ToMoveable();
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!isMove && isHorizontal)
            {
                battery.transform.localEulerAngles = new Vector3(battery.transform.localEulerAngles.x, battery.transform.localEulerAngles.y - eulerWeight, battery.transform.localEulerAngles.z);
            }
            else
            {
                Horizontal();
            }
            //battery.transform.eulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y - eulerWeight, battery.transform.eulerAngles.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!isMove && isHorizontal)
            {
                battery.transform.localEulerAngles = new Vector3(battery.transform.localEulerAngles.x, battery.transform.localEulerAngles.y + eulerWeight, battery.transform.localEulerAngles.z);
            }
            else
            {
                Horizontal();
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!isMove && !isHorizontal)
            {
                battery.transform.localEulerAngles = new Vector3(battery.transform.localEulerAngles.x - eulerWeight, battery.transform.localEulerAngles.y, battery.transform.localEulerAngles.z);
            }
            else
            {
                Vertical();
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!isMove && !isHorizontal)
            {
                battery.transform.localEulerAngles = new Vector3(battery.transform.localEulerAngles.x + eulerWeight, battery.transform.localEulerAngles.y, battery.transform.localEulerAngles.z);
            }
            else
            {
                Vertical();
            }
        }
        else if (Input.GetKey(KeyCode.R))
        {
            if (keyJudge)
            {
                keyJudge = false;
                Reset();
            }
        }
        else
        {
            //if (!bulletJudge && bulletWeight < BULLETWEIGHT)
            //{
            //    bulletWeight++;
            //}
            //else if (!bulletJudge)
            //{
            //    ball = Instantiate(bulletPrefab, battery.transform.position, Quaternion.identity);
            //    Debug.Log("Bullet Charged.");
            //    bulletJudge = true;
            //    bulletWeight = 0;
            //}
            keyJudge = true;

        }



    }


    //public static bool GetIsMove()
    //{
    //    return isMove;
    //}
    void Launch()
    {
        ball.GetComponentInChildren<Rigidbody>().AddExplosionForce(force, bomb.transform.position, radius);
    }
    void Horizontal()
    {
        battery.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        battery.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        if (battery.GetComponent<HingeJoint>() != null)
        {
            Destroy(battery.GetComponent<HingeJoint>());
        }
        if (battery.GetComponent<FixedJoint>() != null)
        {
            Destroy(battery.GetComponent<FixedJoint>());
        }
        HingeJoint hinge = battery.AddComponent<HingeJoint>();
        hinge.axis = new Vector3(0, 1, 0);
        hinge.connectedBody = body.GetComponent<Rigidbody>();
        isMove = false;
        isHorizontal = true;
    }
    void Vertical()
    {
        battery.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        battery.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        if (battery.GetComponent<HingeJoint>() != null)
        {
            Destroy(battery.GetComponent<HingeJoint>());
        }
        if (battery.GetComponent<FixedJoint>() != null)
        {
            Destroy(battery.GetComponent<FixedJoint>());
        }
        HingeJoint hinge = battery.AddComponent<HingeJoint>();
        hinge.axis = new Vector3(1, 0, 0);
        hinge.connectedBody = body.GetComponent<Rigidbody>();
        isMove = false;
        isHorizontal = false;
    }
    void ToMoveable()
    {
        if (battery.GetComponent<HingeJoint>() != null)
        {
            Destroy(battery.GetComponent<HingeJoint>());
        }
        if (battery.GetComponent<FixedJoint>() != null)
        {
            Destroy(battery.GetComponent<FixedJoint>());
        }
        FixedJoint fixedJoint = battery.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = body.GetComponent<Rigidbody>();
        battery.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        isMove = true;
    }
    private void Reset()
    {
        //Horizontal();
        //battery.transform.localEulerAngles = new Vector3(battery.transform.localEulerAngles.x, 0, 0);
        //Vertical();
        //battery.transform.localEulerAngles = new Vector3(0, battery.transform.localEulerAngles.y, 0);
        //ToMoveable();
    }
}

