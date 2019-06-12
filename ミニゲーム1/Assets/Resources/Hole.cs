using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject game;
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OntriggerEnter" + other.name);
        if (other.tag == "BallTrigger")
        {
            //Debug.Log("BallTrigger");
            game = other.gameObject.transform.parent.gameObject;

            if (game.tag == "Ball")
            {
                Main.SetIsFoul();
            }
            else
            {
                Destroy(game);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
