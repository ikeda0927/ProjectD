using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private AudioSource sound01;
    private static bool holeIsTrigger = true;
    // Start is called before the first frame update
    GameObject game;
    CapsuleCollider capsuleCollider;
    void Start()
    {
        sound01 = GetComponent<AudioSource>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
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
                Main.AddScore(game.tag);
                BilliardImage.DestroyBallImage(int.Parse(game.tag));
                Destroy(game);
                sound01.PlayOneShot(sound01.clip);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Ball")
        {
            sound01.PlayOneShot(sound01.clip);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (holeIsTrigger)
        {
            capsuleCollider.isTrigger = true;
        }
        else
        {
            capsuleCollider.isTrigger = false;
        }
    }
    public static void UnsetHoleIsTrigger()
    {
        holeIsTrigger = false;
    }
    public static void SetHoleIsTrigger()
    {
        holeIsTrigger = true;
    }
}
