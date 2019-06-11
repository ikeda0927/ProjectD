using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource sound01;

    // Start is called before the first frame update
    void Start()
    {
        sound01 = GetComponent<AudioSource>();
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
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.V) || Input.GetKey(KeyCode.N))
        {
            if (!sound01.enabled)
            {
                sound01.enabled = true;
            }
            if (!sound01.isPlaying)
            {
                Debug.Log("Sound true");
                sound01.Play();
            }
        }
        else
        {
            Debug.Log("Sound false");
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
