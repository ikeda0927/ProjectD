using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExpload : MonoBehaviour
{
    public GameObject Mine;
    public GameObject Expload;
    public float radius = 5.0F;
    public float power = 10.0F;
    Rigidbody rb;

    void Update(){
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tank")|| collision.gameObject.tag == "Caterpiller1" || collision.gameObject.tag == "Caterpiller2")
        {
            //Debug.Log("物体に衝突しました。");
            Vector3 explosionPos = transform.position;
            GameObject effect =(GameObject)Instantiate(Expload, explosionPos, Quaternion.identity);
            Destroy(Mine);
            Destroy(effect,2.0f);
        }   
    }
}
