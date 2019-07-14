using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoroler : MonoBehaviour
{
    // Start is called before the first frame update
    Camera camera1;
    Camera camera2;
    int cameraNum = 1;
    bool cameraMoved = false;
    Quaternion defaultCamera1Rotation;
    void Start()
    {
        camera1 = GameObject.Find("Camera1").GetComponent<Camera>();
        camera2 = GameObject.Find("Camera2").GetComponent<Camera>();
        camera2.enabled = false;
        camera1.enabled = true;
        defaultCamera1Rotation = camera1.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            cameraNum = 1;
            camera1.enabled = true;
            camera2.enabled = false;
        }
        else if (Input.GetKey("2"))
        {
            cameraNum = 2;
            camera1.enabled = false;
            camera2.enabled = true;
        }
    }
    public int GetCameraNum()
    {
        return cameraNum;
    }
    public Quaternion GetRotationOfCamera1()
    {
        return camera1.transform.rotation;
    }
    public Transform GetTransformOfCamera1()
    {
        return camera1.transform;
    }
    public void SetRotationOfCamera1(Quaternion q)
    {
        camera1.transform.rotation = q;
    }
    public void ChangeView()
    {
        if (cameraMoved)
        {
            camera1.transform.localRotation = defaultCamera1Rotation;
            //camera1.transform.rotation = Quaternion.Euler(defaultCamera1Rotation.eulerAngles.x, defaultCamera1Rotation.eulerAngles.y, defaultCamera1Rotation.eulerAngles.z);
            cameraMoved = false;
        }
        else if (cameraNum == 1)
        {
            camera1.enabled = false;
            camera2.enabled = true;
            cameraNum = 2;
        }
        else
        {
            cameraNum = 1;
            camera1.enabled = true;
            camera2.enabled = false;
        }
    }
    public void SetCameraMoved(bool b)
    {
        cameraMoved = b;
    }
}
