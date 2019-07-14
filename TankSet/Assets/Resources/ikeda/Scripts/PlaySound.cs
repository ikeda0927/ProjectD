using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource sound01;
    Tank tank;

    // Start is called before the first frame update
    void Start()
    {
        sound01 = GetComponent<AudioSource>();
        tank = GameObject.Find("Tank").GetComponent<Tank>();
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) == true || Input.GetKeyDown(KeyCode.B) == true || Input.GetKeyDown(KeyCode.V) == true || Input.GetKeyDown(KeyCode.N) == true)
        //{
        //    if (!sound01.enabled)
        //    {
        //        sound01.enabled = true;
        //    }
        //    Debug.Log("Sound true");
        //    sound01.Play();
        //}
        //else
        //{
        //    Debug.Log("Sound false");
        //    sound01.enabled = false;
        //}
        if (tank.GetIsMoving())
        {
            if (!sound01.enabled)
            {
                sound01.enabled = true;
            }
            if (tank.GetVelocity() < 3f)
            {
                sound01.volume = .1f;
            }
            else if (tank.GetVelocity() < 6f)
            {
                sound01.volume = .2f;
            }
            else if (tank.GetVelocity() < 9f)
            {
                sound01.volume = .3f;
            }
            else if (tank.GetVelocity() < 12f)
            {
                sound01.volume = .4f;
            }
            else if (tank.GetVelocity() < 15f)
            {
                sound01.volume = .5f;
            }
            else if (tank.GetVelocity() < 18f)
            {
                sound01.volume = .6f;
            }
            else if (tank.GetVelocity() < 21f)
            {
                sound01.volume = .7f;
            }
            else if (tank.GetVelocity() < 24f)
            {
                sound01.volume = .8f;
            }
            else if (tank.GetVelocity() < 27f)
            {
                sound01.volume = .9f;
            }
            else if (tank.GetVelocity() < 30f)
            {
                sound01.volume = 1f;
            }
            if (!sound01.isPlaying)
            {
                //Debug.Log("Sound true");
                sound01.Play();
            }
        }
        else if (sound01.enabled && tank.GetVelocity() > 1)
        {
            if (tank.GetVelocity() < 3f)
            {
                sound01.volume = .1f;
            }
            else if (tank.GetVelocity() < 6f)
            {
                sound01.volume = .2f;
            }
            else if (tank.GetVelocity() < 9f)
            {
                sound01.volume = .3f;
            }
            else if (tank.GetVelocity() < 12f)
            {
                sound01.volume = .4f;
            }
            else if (tank.GetVelocity() < 15f)
            {
                sound01.volume = .5f;
            }
            else if (tank.GetVelocity() < 18f)
            {
                sound01.volume = .6f;
            }
            else if (tank.GetVelocity() < 21f)
            {
                sound01.volume = .7f;
            }
            else if (tank.GetVelocity() < 24f)
            {
                sound01.volume = .8f;
            }
            else if (tank.GetVelocity() < 27f)
            {
                sound01.volume = .9f;
            }
            else if (tank.GetVelocity() < 30f)
            {
                sound01.volume = 1f;
            }
        }
        else
        {
            //Debug.Log("Sound false");
            sound01.enabled = false;
        }
        //else if (Input.GetKeyDown(KeyCode.Space) == false && Input.GetKeyDown(KeyCode.B) == false && Input.GetKeyDown(KeyCode.V) == false && Input.GetKeyDown(KeyCode.N) == false)
        //{
        //    //sound01.Stop();
        //}
        /*else if(Input.GetKeyDown(KeyCode.Space) == false)
        {
            sound01.Pause();
        }*/
    }
}
