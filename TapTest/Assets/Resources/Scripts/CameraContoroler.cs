using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoroler : MonoBehaviour
{
    // Start is called before the first frame update
    Camera camera1;
    Camera camera2;
    static int cameraNum = 1;
    void Start()
    {
        camera1 = GameObject.Find("Camera1").GetComponent<Camera>();
        camera2 = GameObject.Find("Camera2").GetComponent<Camera>();
        camera2.enabled = false;
        camera1.enabled = true;
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
    public static int GetCameraNum()
    {
        return cameraNum;
    }
    public void ChangeView()
    {
        if (cameraNum == 1)
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
}
