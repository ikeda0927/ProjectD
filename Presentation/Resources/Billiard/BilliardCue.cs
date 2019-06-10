using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardCue : MonoBehaviour
{
    // Start is called before the first frame update
    bool keyJudge = true;
    const int shotWeight = 40;
    const float WEIGHT = 0.2f;
    public float force = 450f;
    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball")
        {
            Debug.Log("Collision");
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (keyJudge)
            {
                keyJudge = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
                gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Mathf.Sin(gameObject.transform.localRotation.x * Mathf.Deg2Rad) * force, Mathf.Cos(gameObject.transform.localRotation.y * Mathf.Deg2Rad) * force, 0), ForceMode.Impulse);
            }
        }
        else
        {
            keyJudge = true;
        }
    }
}
