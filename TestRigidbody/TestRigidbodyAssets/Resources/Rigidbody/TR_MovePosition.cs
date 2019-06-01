using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_MovePosition : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    const float force = 10f;
    public float weight = .5f;
    bool keyjudge = true;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.MovePosition(rb.position + Vector3.forward * force);
        //rb.MovePosition(new Vector3(18f, 1f, 9f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (keyjudge)
            {
                keyjudge = false;
                rb.MovePosition(new Vector3(rb.position.x + weight, rb.position.y, rb.position.z));
            }
        }
        else
        {
            keyjudge = true;
        }
    }
}
