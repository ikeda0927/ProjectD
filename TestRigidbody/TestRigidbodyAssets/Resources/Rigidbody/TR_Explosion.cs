using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    bool keyjudge = true;
    public float force = 100f;
    public float range = 1f;
    private int DESTROY_TIME = 100;
    private bool destroyJudge = false;
    private int destoryCounter = 0;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (keyjudge)
            {
                var others = Physics.OverlapSphere(gameObject.transform.position, range);
                foreach (Collider other in others)
                {
                    if (other.tag == "Block" || other.tag == "Bomb")
                    {
                        other.GetComponent<Rigidbody>().AddExplosionForce(force, gameObject.transform.position, range);
                    }
                }
                //Destroy(gameObject);
                destroyJudge = true;
            }
        }
        else
        {
            keyjudge = true;
        }
        if (destroyJudge)
        {
            if (destoryCounter < DESTROY_TIME)
            {
                destoryCounter++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
