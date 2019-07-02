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
    public AudioClip sound01;
    private void Start()
    {
       
    }
    void Update(){

    }

    void SoundCreat() {
        GameObject Sound = new GameObject("Sound");
        AudioSource audio = new AudioSource();
        audio = Sound.AddComponent<AudioSource>();
        audio.clip = sound01;
        audio.transform.position = Mine.transform.position;
        audio.spatialBlend = 0;
        audio.loop = false;
        audio.volume = 1.0F;
        audio.Play();
        Destroy(Sound, sound01.length +0.1F);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tank")|| collision.gameObject.tag == "Caterpiller1" || collision.gameObject.tag == "Caterpiller2")
        {
            //Debug.Log("物体に衝突しました。");
            Vector3 explosionPos = transform.position;
            GameObject effect =(GameObject)Instantiate(Expload, explosionPos, Quaternion.identity);

            //AudioSource.PlayClipAtPoint(sound01,transform.position,1.0F);
            SoundCreat();
            Destroy(Mine);
            Destroy(effect,2.0f);
        }   
    }
}
