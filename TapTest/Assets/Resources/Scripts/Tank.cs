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
    float turnWeight = 1.5f;
    public float moveForce = 200f;

    //Battery
    static GameObject bomb;
    GameObject ball;
    static GameObject bulletPrefab;
    static GameObject barrel;
    static GameObject battery;
    static GameObject ballSetPosition;
    float radius = 5f;
    public static int launchForce = 7500;
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

    //contoroller
    float force = 0.01f;
    Vector3 vector;
    Vector2 currentWidthAndHeight;
    int screenPositionNum0 = 0;//left -> 1, middle -> 2, right -> 3
    int[] screenPositionNums = new int[10];
    Dictionary<int, int> screenPositionsNumSet = new Dictionary<int, int>();

    Vector2 touchedPosition;

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

        bulletPrefab = Resources.Load("Bullet6") as GameObject;
        battery = gameObject.transform.Find("Battery").gameObject;
        barrel = gameObject.transform.Find("Battery/Barrel1").gameObject;
        bomb = gameObject.transform.Find("Battery/Barrel1/Barrel2/Barrel3/Bomb").gameObject;
        ballSetPosition = gameObject.transform.Find("Battery/Barrel1/Barrel2/Barrel3/BallSetPosition").gameObject;

        currentWidthAndHeight = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        vector = new Vector3(0, 0, 1);

        hinge = battery.GetComponent<HingeJoint>();
        fixedJoint = battery.GetComponent<FixedJoint>();
    }
    // Update is called once per frame
    void Update()
    { //Trail Test
        isMoving = false;
        //
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Contorol(Input.GetTouch(i));
            }
            //Touch touch0 = Input.GetTouch(0);
            ////text.text = touch0.position.ToString();
            //switch (touch0.phase)
            //{
            //    case TouchPhase.Began:
            //        if (touch0.position.x < currentWidthAndHeight.x / 3)
            //        {
            //            touchedPosition = touch0.position;
            //            screenPositionNum0 = 1;
            //        }
            //        else if (touch0.position.x < (currentWidthAndHeight.x / 3) * 2)
            //        {
            //            touchedPosition = touch0.position;
            //            screenPositionNum0 = 2;
            //        }
            //        else if (touch0.position.x < currentWidthAndHeight.x)
            //        {
            //            touchedPosition = touch0.position;
            //            screenPositionNum0 = 3;
            //        }
            //        break;
            //    case TouchPhase.Moved:
            //        switch (screenPositionNum0)
            //        {
            //            case 1:
            //                //float x = 0;
            //                //float z = 0;
            //                float dx = touch0.position.x - touchedPosition.x;
            //                float dy = touch0.position.y - touchedPosition.y;

            //                if (dx >= 0)
            //                {
            //                    if (dy >= 0)
            //                    {
            //                        if (dx <= dy)
            //                        {
            //                            //move foward
            //                            if (isMove)
            //                            {//Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                rCate1.AddRelativeForce(forceF, ForceMode.Force);
            //                                rCate2.AddRelativeForce(forceF, ForceMode.Force);
            //                            }
            //                            else
            //                            {//Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                ToMoveable();
            //                            }
            //                        }
            //                        else
            //                        {
            //                            //turn right
            //                            if (isMove)
            //                            {
            //                                //Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                rCate1.AddRelativeForce(forceB * turnWeight, ForceMode.Force);
            //                                rCate2.AddRelativeForce(forceF * turnWeight, ForceMode.Force);
            //                            }
            //                            else
            //                            {//Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                ToMoveable();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (-dx < dy)
            //                        {
            //                            //turn right
            //                            if (isMove)
            //                            {
            //                                //Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                rCate1.AddRelativeForce(forceB * turnWeight, ForceMode.Force);
            //                                rCate2.AddRelativeForce(forceF * turnWeight, ForceMode.Force);
            //                            }
            //                            else
            //                            {//Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                ToMoveable();
            //                            }
            //                        }
            //                        else
            //                        {
            //                            //move back
            //                            if (isMove)
            //                            {//Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                rCate1.AddRelativeForce(forceB, ForceMode.Force);
            //                                rCate2.AddRelativeForce(forceB, ForceMode.Force);
            //                            }
            //                            else
            //                            {//Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                ToMoveable();
            //                            }
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    if (dy >= 0)
            //                    {
            //                        if (-dx < dy)
            //                        {
            //                            //move foward
            //                            if (isMove)
            //                            {//Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                rCate1.AddRelativeForce(forceF, ForceMode.Force);
            //                                rCate2.AddRelativeForce(forceF, ForceMode.Force);
            //                            }
            //                            else
            //                            {//Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                ToMoveable();
            //                            }
            //                        }
            //                        else
            //                        {
            //                            //turn left
            //                            if (isMove)
            //                            {
            //                                //Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                rCate1.AddRelativeForce(forceF * turnWeight, ForceMode.Force);
            //                                rCate2.AddRelativeForce(forceB * turnWeight, ForceMode.Force);
            //                            }
            //                            else
            //                            {
            //                                //Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                ToMoveable();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (dx < dy)
            //                        {
            //                            //turn left
            //                            if (isMove)
            //                            {
            //                                //Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                rCate1.AddRelativeForce(forceF * turnWeight, ForceMode.Force);
            //                                rCate2.AddRelativeForce(forceB * turnWeight, ForceMode.Force);
            //                            }
            //                            else
            //                            {
            //                                //Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                ToMoveable();
            //                            }
            //                        }
            //                        else
            //                        {
            //                            //move back
            //                            if (isMove)
            //                            {//Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                rCate1.AddRelativeForce(forceB, ForceMode.Force);
            //                                rCate2.AddRelativeForce(forceB, ForceMode.Force);
            //                            }
            //                            else
            //                            {//Trail Test
            //                                Trail.SetTrailJudge(false);
            //                                isMoving = true;
            //                                //
            //                                ToMoveable();
            //                            }
            //                        }
            //                    }
            //                }

            //                //if (touchedPosition.x < touch0.position.x)
            //                //{
            //                //    x = 1;
            //                //}
            //                //else if (touchedPosition.x > touch0.position.x)
            //                //{
            //                //    x = -1;
            //                //}
            //                //else if (touchedPosition.y < touch0.position.y)
            //                //{
            //                //    z = 1;
            //                //}
            //                //else if (touchedPosition.y > touch0.position.y)
            //                //{
            //                //    z = -1;
            //                //}
            //                //rb.AddForce(new Vector3(x, 0, z) * force);
            //                //rb.AddForce(new Vector3(touch0.position.x - touchedPosition.x, 0, touch0.position.y - touchedPosition.y) * force);
            //                break;
            //            case 2:
            //                break;
            //            case 3:
            //                break;
            //        }
            //        break;
            //    case TouchPhase.Ended:
            //        screenPositionNum0 = 0;
            //        break;
            //}

        }
        else if (Input.GetMouseButtonDown(0))
        {
            //text.text = Input.mousePosition.ToString();
            if (Input.mousePosition.x < currentWidthAndHeight.x / 3)
            {
                touchedPosition = Input.mousePosition;
                screenPositionNum0 = 1;
            }
            else if (Input.mousePosition.x < (currentWidthAndHeight.x / 3) * 2)
            {
                touchedPosition = Input.mousePosition;
                screenPositionNum0 = 2;

            }
            else if (Input.mousePosition.x < currentWidthAndHeight.x)
            {
                touchedPosition = Input.mousePosition;
                screenPositionNum0 = 3;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            switch (screenPositionNum0)
            {
                case 1:
                case 3:
                    float dx = Input.mousePosition.x - touchedPosition.x;
                    float dy = Input.mousePosition.y - touchedPosition.y;
                    if (dx >= 0)
                    {
                        if (dy >= 0)
                        {
                            if (dx <= dy)
                            {
                                if (screenPositionNum0 == 1)
                                {
                                    //move foward
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
                                else
                                {
                                    if (dx == 0 && dy == 0) { }
                                    else
                                    {
                                        //barrel up
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
                                }
                            }
                            else
                            {
                                if (screenPositionNum0 == 1)
                                {
                                    //turn right
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
                                else
                                {
                                    //battery right
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
                            }
                        }
                        else
                        {
                            if (-dx < dy)
                            {
                                if (screenPositionNum0 == 1)
                                {
                                    //turn right
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
                                else
                                {
                                    //battery right
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
                            }
                            else
                            {
                                if (screenPositionNum0 == 1)
                                {
                                    //move back
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
                                else
                                {
                                    //barrel down
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
                            }
                        }
                    }
                    else
                    {
                        if (dy >= 0)
                        {
                            if (-dx < dy)
                            {
                                if (screenPositionNum0 == 1)
                                {
                                    //move foward
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
                                else
                                {
                                    //barrel up
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
                            }
                            else
                            {
                                if (screenPositionNum0 == 1)
                                {
                                    //turn left
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
                                else
                                {
                                    //battery left
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
                            }
                        }
                        else
                        {
                            if (dx < dy)
                            {
                                if (screenPositionNum0 == 1)
                                {
                                    //turn left
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
                                else
                                {
                                    //battery left
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
                            }
                            else
                            {
                                if (screenPositionNum0 == 1)
                                {
                                    //move back
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
                                else
                                {
                                    //barrel down
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
                            }
                        }
                    }
                    //float x = 0;
                    //float z = 0;
                    //if (touchedPosition.x < Input.mousePosition.x)
                    //{
                    //    x = 1;
                    //}
                    //else if (touchedPosition.x > Input.mousePosition.x)
                    //{
                    //    x = -1;
                    //}
                    //else if (touchedPosition.y < Input.mousePosition.y)
                    //{
                    //    z = 1;
                    //}
                    //else if (touchedPosition.y > Input.mousePosition.y)
                    //{
                    //    z = -1;
                    //}
                    //rb.AddForce(new Vector3(x, 0, z) * force);
                    //rb.AddForce(new Vector3(Input.mousePosition.x - touchedPosition.x, 0, Input.mousePosition.y - touchedPosition.y) * force);
                    break;
                case 2:
                    break;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
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
    void Contorol(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                if (touch.position.x < currentWidthAndHeight.x / 3)
                {
                    touchedPosition = touch.position;
                    screenPositionsNumSet.Add(touch.fingerId, 1);
                    //screenPositionNum0 = 1;
                }
                else if (touch.position.x < (currentWidthAndHeight.x / 3) * 2)
                {
                    touchedPosition = touch.position;
                    screenPositionsNumSet.Add(touch.fingerId, 2);
                    //screenPositionNum0 = 2;
                }
                else if (touch.position.x < currentWidthAndHeight.x)
                {
                    touchedPosition = touch.position;
                    screenPositionsNumSet.Add(touch.fingerId, 3);
                    //screenPositionNum0 = 3;
                }
                break;
            case TouchPhase.Moved:
                int spns = screenPositionsNumSet[touch.fingerId];
                switch (spns)
                {
                    case 1:
                    case 3:
                        //float x = 0;
                        //float z = 0;
                        float dx = touch.position.x - touchedPosition.x;
                        float dy = touch.position.y - touchedPosition.y;

                        if (dx >= 0)
                        {
                            if (dy >= 0)
                            {
                                if (dx <= dy)
                                {
                                    if (spns == 1)
                                    {
                                        //move foward
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
                                    else
                                    {
                                        if (dx == 0 && dy == 0) { }
                                        else
                                        {
                                            //barrel up
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
                                    }
                                }
                                else
                                {
                                    if (spns == 1)
                                    {
                                        //turn right
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
                                    else
                                    {
                                        //battery right
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
                                }
                            }
                            else
                            {
                                if (-dx < dy)
                                {
                                    if (spns == 1)
                                    {
                                        //turn right
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
                                    else
                                    {
                                        //battery right
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
                                }
                                else
                                {
                                    if (spns == 1)
                                    {
                                        //move back
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
                                    else
                                    {
                                        //barrel down
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
                                }
                            }
                        }
                        else
                        {
                            if (dy >= 0)
                            {
                                if (-dx < dy)
                                {
                                    if (spns == 1)
                                    {
                                        //move foward
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
                                    else
                                    {
                                        //barrel up
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
                                }
                                else
                                {
                                    if (spns == 1)
                                    {
                                        //turn left
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
                                    else
                                    {
                                        //battery left
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
                                }
                            }
                            else
                            {
                                if (dx < dy)
                                {
                                    if (spns == 1)
                                    {
                                        //turn left
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
                                    else
                                    {
                                        //battery left
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
                                }
                                else
                                {
                                    if (spns == 1)
                                    {
                                        //move back
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
                                    else
                                    {
                                        //barrel down
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
                                }
                            }
                        }

                        //if (touchedPosition.x < touch0.position.x)
                        //{
                        //    x = 1;
                        //}
                        //else if (touchedPosition.x > touch0.position.x)
                        //{
                        //    x = -1;
                        //}
                        //else if (touchedPosition.y < touch0.position.y)
                        //{
                        //    z = 1;
                        //}
                        //else if (touchedPosition.y > touch0.position.y)
                        //{
                        //    z = -1;
                        //}
                        //rb.AddForce(new Vector3(x, 0, z) * force);
                        //rb.AddForce(new Vector3(touch0.position.x - touchedPosition.x, 0, touch0.position.y - touchedPosition.y) * force);
                        break;
                    case 2:
                        break;
                }
                break;
            case TouchPhase.Ended:
                screenPositionsNumSet.Remove(touch.fingerId);
                break;
        }
        /*
        //
        switch (screenPositionNum0)
        {
            case 1:
            case 3:
                float dx = touch.position.x - touchedPosition.x;
                float dy = touch.position.y - touchedPosition.y;
                if (dx >= 0)
                {
                    if (dy >= 0)
                    {
                        if (dx <= dy)
                        {
                            //if (screenPositionNum0 == 1)
                            //{
                            //    //move foward
                            //    if (isMove)
                            //    {//Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        rCate1.AddRelativeForce(forceF, ForceMode.Force);
                            //        rCate2.AddRelativeForce(forceF, ForceMode.Force);
                            //    }
                            //    else
                            //    {//Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        ToMoveable();
                            //    }
                            //}
                            //else
                            //{
                            //    if (dx == 0 && dy == 0) { }
                            //    else
                            //    {
                            //        //barrel up
                            //        if (!isMove && !isHorizontal)
                            //        {
                            //            if (CameraContoroler.GetCameraNum() == 2)
                            //            {

                            //                barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x - verticalBarrelMoveWeightCamera2, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                            //            }
                            //            else
                            //            {

                            //                barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x - verticalBarrelMoveWeight, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                            //            }
                            //        }
                            //        else
                            //        {
                            //            Vertical();
                            //        }
                            //    }
                            //}
                        }
                        else
                        {
                            //if (screenPositionNum0 == 1)
                            //{
                            //    //turn right
                            //    if (isMove)
                            //    {
                            //        //Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        rCate1.AddRelativeForce(forceB * turnWeight, ForceMode.Force);
                            //        rCate2.AddRelativeForce(forceF * turnWeight, ForceMode.Force);
                            //    }
                            //    else
                            //    {//Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        ToMoveable();
                            //    }
                            //}
                            //else
                            //{
                            //    //battery right
                            //    if (!isMove && isHorizontal)
                            //    {
                            //        if (CameraContoroler.GetCameraNum() == 2)
                            //        {
                            //            battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y + horizontalBatteryMoveWeightCamera2, battery.transform.eulerAngles.z);
                            //        }
                            //        else
                            //        {
                            //            battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y + horizontalBatteryMoveWeight, battery.transform.eulerAngles.z);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        Horizontal();
                            //    }
                            //}
                        }
                    }
                    else
                    {
                        if (-dx < dy)
                        {
                            //if (screenPositionNum0 == 1)
                            //{
                            //    //turn right
                            //    if (isMove)
                            //    {
                            //        //Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        rCate1.AddRelativeForce(forceB * turnWeight, ForceMode.Force);
                            //        rCate2.AddRelativeForce(forceF * turnWeight, ForceMode.Force);
                            //    }
                            //    else
                            //    {//Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        ToMoveable();
                            //    }
                            //}
                            //else
                            //{
                            //    //battery right
                            //    if (!isMove && isHorizontal)
                            //    {
                            //        if (CameraContoroler.GetCameraNum() == 2)
                            //        {
                            //            battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y + horizontalBatteryMoveWeightCamera2, battery.transform.eulerAngles.z);
                            //        }
                            //        else
                            //        {
                            //            battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y + horizontalBatteryMoveWeight, battery.transform.eulerAngles.z);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        Horizontal();
                            //    }
                            //}
                        }
                        else
                        {
                            //if (screenPositionNum0 == 1)
                            //{
                            //    //move back
                            //    if (isMove)
                            //    {//Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        rCate1.AddRelativeForce(forceB, ForceMode.Force);
                            //        rCate2.AddRelativeForce(forceB, ForceMode.Force);
                            //    }
                            //    else
                            //    {//Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        ToMoveable();
                            //    }
                            //}
                            //else
                            //{
                            //    //barrel down
                            //    if (!isMove && !isHorizontal)
                            //    {
                            //        if (CameraContoroler.GetCameraNum() == 2)
                            //        {

                            //            barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x + verticalBarrelMoveWeightCamera2, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                            //        }
                            //        else
                            //        {

                            //            barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x + verticalBarrelMoveWeight, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                            //        }
                            //    }
                            //    else
                            //    {
                            //        Vertical();
                            //    }
                            //}
                        }
                    }
                }
                else
                {
                    if (dy >= 0)
                    {
                        if (-dx < dy)
                        {
                            //if (screenPositionNum0 == 1)
                            //{
                            //    //move foward
                            //    if (isMove)
                            //    {//Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        rCate1.AddRelativeForce(forceF, ForceMode.Force);
                            //        rCate2.AddRelativeForce(forceF, ForceMode.Force);
                            //    }
                            //    else
                            //    {//Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        ToMoveable();
                            //    }
                            //}
                            //else
                            //{
                            //    //barrel up
                            //    if (!isMove && !isHorizontal)
                            //    {
                            //        if (CameraContoroler.GetCameraNum() == 2)
                            //        {

                            //            barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x - verticalBarrelMoveWeightCamera2, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                            //        }
                            //        else
                            //        {

                            //            barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x - verticalBarrelMoveWeight, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                            //        }
                            //    }
                            //    else
                            //    {
                            //        Vertical();
                            //    }
                            //}
                        }
                        else
                        {
                            //if (screenPositionNum0 == 1)
                            //{
                            //    //turn left
                            //    if (isMove)
                            //    {
                            //        //Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        rCate1.AddRelativeForce(forceF * turnWeight, ForceMode.Force);
                            //        rCate2.AddRelativeForce(forceB * turnWeight, ForceMode.Force);
                            //    }
                            //    else
                            //    {
                            //        //Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        ToMoveable();
                            //    }
                            //}
                            //else
                            //{
                            //    //battery left
                            //    if (!isMove && isHorizontal)
                            //    {
                            //        if (CameraContoroler.GetCameraNum() == 2)
                            //        {

                            //            battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y - horizontalBatteryMoveWeightCamera2, battery.transform.eulerAngles.z);
                            //        }
                            //        else
                            //        {

                            //            battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y - horizontalBatteryMoveWeight, battery.transform.eulerAngles.z);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        Horizontal();
                            //    }
                            //}
                        }
                    }
                    else
                    {
                        if (dx < dy)
                        {
                            //if (screenPositionNum0 == 1)
                            //{
                            //    //turn left
                            //    if (isMove)
                            //    {
                            //        //Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        rCate1.AddRelativeForce(forceF * turnWeight, ForceMode.Force);
                            //        rCate2.AddRelativeForce(forceB * turnWeight, ForceMode.Force);
                            //    }
                            //    else
                            //    {
                            //        //Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        ToMoveable();
                            //    }
                            //}
                            //else
                            //{
                            //    //battery left
                            //    if (!isMove && isHorizontal)
                            //    {
                            //        if (CameraContoroler.GetCameraNum() == 2)
                            //        {

                            //            battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y - horizontalBatteryMoveWeightCamera2, battery.transform.eulerAngles.z);
                            //        }
                            //        else
                            //        {

                            //            battery.transform.localEulerAngles = new Vector3(battery.transform.eulerAngles.x, battery.transform.eulerAngles.y - horizontalBatteryMoveWeight, battery.transform.eulerAngles.z);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        Horizontal();
                            //    }
                            //}
                        }
                        else
                        {
                            //if (screenPositionNum0 == 1)
                            //{
                            //    //move back
                            //    if (isMove)
                            //    {//Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        rCate1.AddRelativeForce(forceB, ForceMode.Force);
                            //        rCate2.AddRelativeForce(forceB, ForceMode.Force);
                            //    }
                            //    else
                            //    {//Trail Test
                            //        Trail.SetTrailJudge(false);
                            //        isMoving = true;
                            //        //
                            //        ToMoveable();
                            //    }
                            //}
                            //else
                            //{
                            //    //barrel down
                            //    if (!isMove && !isHorizontal)
                            //    {
                            //        if (CameraContoroler.GetCameraNum() == 2)
                            //        {

                            //            barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x + verticalBarrelMoveWeightCamera2, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                            //        }
                            //        else
                            //        {

                            //            barrel.transform.localEulerAngles = new Vector3(barrel.transform.localEulerAngles.x + verticalBarrelMoveWeight, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);

                            //        }
                            //    }
                            //    else
                            //    {
                            //        Vertical();
                            //    }
                            //}
                        }
                    }
                }
                //float x = 0;
                //float z = 0;
                //if (touchedPosition.x < Input.mousePosition.x)
                //{
                //    x = 1;
                //}
                //else if (touchedPosition.x > Input.mousePosition.x)
                //{
                //    x = -1;
                //}
                //else if (touchedPosition.y < Input.mousePosition.y)
                //{
                //    z = 1;
                //}
                //else if (touchedPosition.y > Input.mousePosition.y)
                //{
                //    z = -1;
                //}
                //rb.AddForce(new Vector3(x, 0, z) * force);
                //rb.AddForce(new Vector3(Input.mousePosition.x - touchedPosition.x, 0, Input.mousePosition.y - touchedPosition.y) * force);
                break;
            case 2:
                break;
        }
        */
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
    public void Fire()
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
}
