using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_Torque : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float force = 20f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                rb.AddRelativeTorque(Vector3.up);
            }
            else
            {
                rb.AddTorque(Vector3.up);
            }
        }
    }
}
