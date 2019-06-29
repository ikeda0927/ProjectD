using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxContoroller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    float force = 0.01f;
    Vector3 vector;
    Text text;
    Vector2 currentWidthAndHeight;
    int screenPositionNum0 = 0;//left -> 1, middle -> 2, right -> 3
    Vector2 touchedPosition;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        vector = new Vector3(0, 0, 1);
        text = GameObject.FindWithTag("text").GetComponent<Text>();
        currentWidthAndHeight = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        text.text = currentWidthAndHeight.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch0 = Input.GetTouch(0);
            //text.text = touch0.position.ToString();
            switch (touch0.phase)
            {
                case TouchPhase.Began:
                    if (touch0.position.x < currentWidthAndHeight.x / 3)
                    {
                        text.text = "Left";
                        touchedPosition = touch0.position;
                        screenPositionNum0 = 1;
                    }
                    else if (touch0.position.x < (currentWidthAndHeight.x / 3) * 2)
                    {
                        text.text = "Middle";
                        touchedPosition = touch0.position;
                        screenPositionNum0 = 2;
                    }
                    else if (touch0.position.x < currentWidthAndHeight.x)
                    {
                        text.text = "Right";
                        touchedPosition = touch0.position;
                        screenPositionNum0 = 3;
                    }
                    break;
                case TouchPhase.Moved:
                    switch (screenPositionNum0)
                    {
                        case 1:
                            //float x = 0;
                            //float z = 0;
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
                            rb.AddForce(new Vector3(touch0.position.x - touchedPosition.x, 0, touch0.position.y - touchedPosition.y) * force);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    break;
                case TouchPhase.Ended:
                    screenPositionNum0 = 0;
                    break;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            //text.text = Input.mousePosition.ToString();
            if (Input.mousePosition.x < currentWidthAndHeight.x / 3)
            {
                text.text = "Left";
                touchedPosition = Input.mousePosition;
                screenPositionNum0 = 1;
            }
            else if (Input.mousePosition.x < (currentWidthAndHeight.x / 3) * 2)
            {
                text.text = "Middle";
                touchedPosition = Input.mousePosition;
                screenPositionNum0 = 2;

            }
            else if (Input.mousePosition.x < currentWidthAndHeight.x)
            {
                text.text = "Right";
                touchedPosition = Input.mousePosition;
                screenPositionNum0 = 3;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            switch (screenPositionNum0)
            {
                case 1:
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
                    rb.AddForce(new Vector3(Input.mousePosition.x - touchedPosition.x, 0, Input.mousePosition.y - touchedPosition.y) * force);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }

}
