using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Cue")
        {
            Main.SetShotJudge(true);
        }
        else
        if (Main.GetShotJudge() && collision.transform.tag == Main.GetLeastNumber().ToString())
        {
            Main.SetShotJudge(false);
            Main.SubstructTheRest();
            Debug.Log("the Rest is " + Main.GetRest());
        }
        else
        if (Main.GetShotJudge() && collision.transform.tag != Main.GetLeastNumber().ToString() && collision.transform.tag != "Untagged")
        {
            Debug.Log("Called");
            Main.SetIsFoul();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
