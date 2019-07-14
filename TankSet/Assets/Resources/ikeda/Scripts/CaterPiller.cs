using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterPiller : MonoBehaviour
{
    public int caterpillerNum;
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Untagged")
        {
            //Debug.Log("Collision Exit : " + caterpillerNum.ToString());
            if (caterpillerNum == 1)
            {
                Tank.SetCaterpiller1_1Judge(false);
            }
            else if (caterpillerNum == 2)
            {
                Tank.SetCaterpiller2_1Judge(false);
            }
            else if (caterpillerNum == 3)
            {
                Tank.SetCaterpiller1_2Judge(false);
            }
            else if (caterpillerNum == 4)
            {
                Tank.SetCaterpiller2_2Judge(false);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Untagged")
        {
            //Debug.Log("Collision Stay : " + caterpillerNum.ToString());
            if (caterpillerNum == 1)
            {
                Tank.SetCaterpiller1_1Judge(true);
            }
            else if (caterpillerNum == 2)
            {
                Tank.SetCaterpiller2_1Judge(true);
            }
            else if (caterpillerNum == 3)
            {
                Tank.SetCaterpiller1_2Judge(true);
            }
            else if (caterpillerNum == 4)
            {
                Tank.SetCaterpiller2_2Judge(true);
            }
        }
    }
}
