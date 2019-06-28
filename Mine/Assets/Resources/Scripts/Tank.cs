using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    //Caterpiller
    GameObject cate1;
    GameObject cate2;
    Rigidbody rCate1;
    Rigidbody rCate2;
    Vector3 forceF;
    Vector3 forceB;
    int turnWeight = 3;
    public float moveForce = 400f;

    //Battery
    static GameObject bomb;
    GameObject ball;
    static GameObject bulletPrefab;
    static GameObject barrel;
    static GameObject battery;
    static GameObject ballSetPosition;
    float radius = 5f;
    public static int launchForce = 5000;
    bool bulletJudge = true;
    const int BULLETWEIGHT = 20;
    int bulletWeight;
    float verticalBarrelMoveWeight = .2f;
    float horizontalBatteryMoveWeight = .5f;
    float verticalBarrelMoveWeightCamera2 = .1f;
    float horizontalBatteryMoveWeightCamera2 = .2f;
    HingeJoint hinge;
    FixedJoint fixedJoint;

    //I/O
    bool keyJudge2 = true;
    const float eulerWeight = 1f;

    float bulletPositionWeight = .5f;
    //bool firstGetIsMove = true;
    bool isMove;
    bool isHorizontal;
    static GameObject body;
    AudioSource bomb3;

    //Simulate
    static GameObject bulletForSimulate;
    bool isMoving;
    void Start()
    {
        bomb3 = GetComponent<AudioSource>();

        cate1 = gameObject.transform.Find("Caterpiller/Caterpiller1").gameObject;
        cate2 = gameObject.transform.Find("Caterpiller/Caterpiller2").gameObject;
        rCate1 = cate1.GetComponent<Rigidbody>();
        rCate2 = cate2.GetComponent<Rigidbody>();
        forceF = new Vector3(0, -moveForce, 0);
        forceB = new Vector3(0, moveForce, 0);

        body = gameObject.transform.Find("Body").gameObject;

        bulletPrefab = Resources.Load("Bullet3") as GameObject;
        battery = gameObject.transform.Find("Battery").gameObject;
        barrel = gameObject.transform.Find("Battery/Barrel1").gameObject;
        bomb = gameObject.transform.Find("Battery/Barrel1/Barrel2/Barrel3/Bomb").gameObject;
        ballSetPosition = gameObject.transform.Find("Battery/Barrel1/Barrel2/Barrel3/BallSetPosition").gameObject;

        hinge = battery.GetComponent<HingeJoint>();
        fixedJoint = battery.GetComponent<FixedJoint>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Trail Test
            Trail.SetTrailJudge(false);
            //
            if (!isMoving)
            {
                SetTanKinematic(true);
            }
            else
            {
                SetTanKinematic(false);
            }
            if (keyJudge2 && bulletJudge)
            {
                keyJudge2 = false;
                if (hinge != null)
                {
                    battery.GetComponent<Rigidbody>().isKinematic = true;
                }
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
                //Debug.Log("Bullet Charged.");
                if (hinge != null)
                {
                    battery.GetComponent<Rigidbody>().isKinematic = false;
                }
                bulletJudge = true;
                bulletWeight = 0;
            }
            keyJudge2 = true;
        }

        //Trail Test
        isMoving = false;
        //

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (!isMove && isHorizontal)
                {
                    if (CameraContoroler.GetCameraNum() == 2)
                    {

                        battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y - horizontalBatteryMoveWeightCamera2, battery.transform.eulerAngles.z);
                    }
                    else
                    {

                        battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y - horizontalBatteryMoveWeight, battery.transform.eulerAngles.z);
                    }
                }
                else
                {
                    Horizontal();
                }
            }
            else
            if (isMove)
            {
                //Trail Test
                Trail.SetTrailJudge(false);
                isMoving = true;
                //
                rCate1.AddRelativeForce(forceF * turnWeight, ForceMode.Force);
                rCate2.AddRelativeForce(forceB * turnWeight, ForceMode.Force);
            }
            else
            {
                //Trail Test
                Trail.SetTrailJudge(false);
                isMoving = true;
                //
                ToMoveable();
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.RightArrow))
            {
                if (!isMove && isHorizontal)
                {
                    if (CameraContoroler.GetCameraNum() == 2)
                    {
                        battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y + horizontalBatteryMoveWeightCamera2, battery.transform.eulerAngles.z);
                    }
                    else
                    {
                        battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y + horizontalBatteryMoveWeight, battery.transform.eulerAngles.z);
                    }
                }
                else
                {
                    Horizontal();
                }
            }
            else
            if (isMove)
            {
                //Trail Test
                Trail.SetTrailJudge(false);
                isMoving = true;
                //
                rCate1.AddRelativeForce(forceB * turnWeight, ForceMode.Force);
                rCate2.AddRelativeForce(forceF * turnWeight, ForceMode.Force);
            }
            else
            {//Trail Test
                Trail.SetTrailJudge(false);
                isMoving = true;
                //
                ToMoveable();
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.UpArrow))
            {
                if (!isMove && !isHorizontal)
                {
                    if (CameraContoroler.GetCameraNum() == 2)
                    {

                        barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x - verticalBarrelMoveWeightCamera2, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                    }
                    else
                    {

                        barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x - verticalBarrelMoveWeight, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                    }
                }
                else
                {
                    Vertical();
                }
            }
            else
            if (isMove)
            {//Trail Test
                Trail.SetTrailJudge(false);
                isMoving = true;
                //
                rCate1.AddRelativeForce(forceF, ForceMode.Force);
                rCate2.AddRelativeForce(forceF, ForceMode.Force);
            }
            else
            {//Trail Test
                Trail.SetTrailJudge(false);
                isMoving = true;
                //
                ToMoveable();
            }
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.DownArrow))
            {
                if (!isMove && !isHorizontal)
                {
                    if (CameraContoroler.GetCameraNum() == 2)
                    {

                        barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x + verticalBarrelMoveWeightCamera2, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                    }
                    else
                    {

                        barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x + verticalBarrelMoveWeight, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                    }
                }
                else
                {
                    Vertical();
                }
            }
            else
            if (isMove)
            {//Trail Test
                Trail.SetTrailJudge(false);
                isMoving = true;
                //
                rCate1.AddRelativeForce(forceB, ForceMode.Force);
                rCate2.AddRelativeForce(forceB, ForceMode.Force);
            }
            else
            {//Trail Test
                Trail.SetTrailJudge(false);
                isMoving = true;
                //
                ToMoveable();
            }
        }
    }
    void Launch()
    {
        ball = Instantiate(bulletPrefab, new Vector3(ballSetPosition.transform.position.x, ballSetPosition.transform.position.y, ballSetPosition.transform.position.z), battery.transform.rotation);
        if (ball != null)
        {
            ball.GetComponentInChildren<Rigidbody>().AddExplosionForce(launchForce, bomb.transform.position, radius);
        }
    }
    void Horizontal()
    {
        if (battery.GetComponent<HingeJoint>() != null)
        {
            Destroy(battery.GetComponent<HingeJoint>());
        }
        if (battery.GetComponent<FixedJoint>() != null)
        {
            Destroy(battery.GetComponent<FixedJoint>());
        }
        hinge = battery.AddComponent<HingeJoint>();
        hinge.axis = new Vector3(0, 0, 1);
        hinge.connectedBody = body.GetComponent<Rigidbody>();
        hinge.anchor = new Vector3(0, 0, 0);
        isMove = false;
        isHorizontal = true;
    }
    void Vertical()
    {
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
        fixedJoint = battery.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = body.GetComponent<Rigidbody>();
        battery.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        isMove = true;
    }
    public static GameObject MakeBullet()
    {
        //if (bulletForSimulate != null)
        //{
        //    Destroy(bulletForSimulate);
        //}
        bulletForSimulate = Instantiate(bulletPrefab, new Vector3(ballSetPosition.transform.position.x, ballSetPosition.transform.position.y, ballSetPosition.transform.position.z), battery.transform.rotation);
        bulletForSimulate.GetComponent<Bullet>().enabled = false;
        Destroy(bulletForSimulate.transform.GetChild(0).gameObject);
        return bulletForSimulate;
    }
    public static void RemoveBullet()
    {
        if (bulletForSimulate != null)
        {
            Destroy(bulletForSimulate.gameObject);
        }
    }
    public static int GetPower()
    {
        return launchForce;
    }
    public static Quaternion GetBarrelRotation()
    {
        return barrel.transform.localRotation;
    }
    public static Quaternion GetBatteryRotation()
    {
        return battery.transform.localRotation;
    }
    public static Vector3 GetExplosionPosition()
    {
        return bomb.transform.position;
    }
    public static Vector3 GetBallSetPosition()
    {
        return ballSetPosition.transform.position;
    }
    public static void SetTanKinematic(bool b)
    {
        body.GetComponent<Rigidbody>().isKinematic = b;
        battery.GetComponent<Rigidbody>().isKinematic = b;
    }
}
