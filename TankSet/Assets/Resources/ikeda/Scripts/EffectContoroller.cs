using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectContoroller : MonoBehaviour
{
    GameObject bigExplosion;
    GameObject frame;
    // Start is called before the first frame update
    void Start()
    {
        bigExplosion = transform.Find("BigExplosionEffect").gameObject;
        frame = transform.Find("FlamesParticleEffect").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (bigExplosion.GetComponent<ParticleSystem>().isStopped && frame.GetComponent<ParticleSystem>().isStopped)
            Destroy(gameObject);
    }
}
