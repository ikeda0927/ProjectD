using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExpload : MonoBehaviour
{
    public GameObject Mine;
    public float radius = 5.0F;
    public float power = 10.0F;
    Rigidbody rb;

    /*void Update()
    {
            if(Input.GetKey(KeyCode.M)){
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
            Instantiate(Bomb, explosionPos, Quaternion.identity);
            Destroy(Bomb);

            }
    }*/
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
        Instantiate(Mine, explosionPos, Quaternion.identity);
        Destroy(Mine);
    }
}


