using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controler : MonoBehaviour
{

    private static bool moveLeft = false;
    private static bool moveRight = false;
    private static bool moveFoward = false;
    private static bool moveBack = false;
    private static bool changeAngle = false;
    private static bool push = false;

    public void MoveLeft()
    {
        Debug.Log("MoveLeft");
        moveLeft = true;
    }
    public void MoveRight()
    {
        Debug.Log("MoveRIGHT");
        moveRight = true;
    }
    public void MoveFoward()
    {
        Debug.Log("MoveFOWard");
        moveFoward = true;
    }
    public void MoveBack()
    {
        Debug.Log("MoveBack");
        moveBack = true;
    }
    public void ChangeAngle()
    {
        changeAngle = true;
    }
    public void StartPushCue()
    {
        push = true;
    }
    public void StopLeft()
    {
        Debug.Log("MoveLeft");
        moveLeft = false;
    }
    public void StopRight()
    {
        Debug.Log("MoveRIGHT");
        moveRight = false;
    }
    public void StopFoward()
    {
        Debug.Log("MoveFOWard");
        moveFoward = false;
    }
    public void StopBack()
    {
        Debug.Log("MoveBack");
        moveBack = false;
    }
    public void StopChangeAngle()
    {
        changeAngle = false;
    }
    //public void StopPushCue()
    //{
    //    push = false;
    //}
    public static void StopPush()
    {
        push = false;
    }
    public static bool GetMoveLeft()
    {
        return moveLeft;
    }
    public static bool GetMoveRight()
    {
        return moveRight;
    }
    public static bool GetMoveFoward()
    {
        return moveFoward;
    }
    public static bool GetMoveBack()
    {
        return moveBack;
    }
    public static bool GetChangeAngle()
    {
        return changeAngle;
    }
    public static bool GetPush()
    {
        return push;
    }
}
