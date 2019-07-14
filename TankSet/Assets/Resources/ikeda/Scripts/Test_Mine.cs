using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Mine : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Transform[] transforms = collision.gameObject.GetComponentsInParent<Transform>();
        if (transforms.Length > 1 && transforms[2].tag == "Tank")
        {
            //Debug.Log("Mine Explosion");
            //gameObject.SetActive(false);
            if (transforms[2].gameObject.GetComponentInParent<Tank>())
            {
                //Debug.Log("Test Mine Jump");
                transforms[2].gameObject.GetComponentInParent<Tank>().Jump(gameObject.transform.position);
            }
        }
    }
}
