using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndRecovery : MonoBehaviour
{

    GameObject ring;
    GameObject hit;
    GameObject circle;
    GameObject curtain1;
    GameObject curtain2;
    public bool onlySave = false;
    public bool onlyRecovery = false;
    public bool saveAndRecovery = true;
    //rotationは好きな向きに設定してください。(デフォルトではQuaternion.identity)
    public Vector3 rotation = Quaternion.identity.eulerAngles;
    Quaternion rotationQ;
    Vector3 position;
    //// Start is called before the first frame update
    void Start()
    {
        ring = transform.Find("ring1").gameObject;
        hit = transform.Find("Hit_05").gameObject;
        circle = transform.Find("01_B").gameObject;
        curtain1 = transform.Find("02").gameObject;
        curtain1 = transform.Find("02/02_B").gameObject;
        position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        rotationQ = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        if (onlySave)
        {
            SetCircleColor(Color.yellow);
            SetGradientColor(Color.yellow);
        }
        else if (onlyRecovery)
        {
            SetCircleColor(Color.cyan);
            SetGradientColor(Color.cyan);
        }
        else if (saveAndRecovery)
        {
            SetCircleColor(Color.magenta);
            SetGradientColor(Color.magenta);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tank")
        {
            Debug.Log("Tank Enter in the magic circle.");

            if (onlySave)
            {
                other.gameObject.GetComponentInParent<Tank>().SetSavedPosition(position, rotationQ);
                HitEffect();
            }
            else if (onlyRecovery)
            {
                other.gameObject.GetComponentInParent<HP_Contoroller>().Init();
                RingEffect();
            }
            else if (saveAndRecovery)
            {
                other.gameObject.GetComponentInParent<Tank>().SetSavedPosition(position, rotationQ);
                other.gameObject.GetComponentInParent<HP_Contoroller>().Init();
                HitEffect();
                RingEffect();
            }


        }
    }
    void SetCircleColor(Color c)
    {
        ParticleSystem.MinMaxGradient color = new ParticleSystem.MinMaxGradient
        {
            mode = ParticleSystemGradientMode.Color,
            color = c
        };
        ParticleSystem.MainModule main = circle.GetComponent<ParticleSystem>().main;
        main.startColor = color;
    }
    void SetGradientColor(Color c)
    {
        //Create Gradient key
        GradientColorKey[] gradientColorKey;
        gradientColorKey = new GradientColorKey[3];
        gradientColorKey[0].color = c;
        gradientColorKey[0].time = 0f;

        //Create Gradient alpha
        GradientAlphaKey[] gradientAlphaKey;
        gradientAlphaKey = new GradientAlphaKey[3];
        gradientAlphaKey[0].alpha = 0.0f;
        gradientAlphaKey[0].time = 0.0f;
        gradientAlphaKey[1].alpha = 0.4f;
        gradientAlphaKey[1].time = 0.2f;
        gradientAlphaKey[2].alpha = .0f;
        gradientAlphaKey[2].time = 1f;

        //Create Gradient
        Gradient gradient = new Gradient();
        gradient.SetKeys(gradientColorKey, gradientAlphaKey);

        //Create Color from Gradient
        ParticleSystem.MinMaxGradient color = new ParticleSystem.MinMaxGradient();
        color.mode = ParticleSystemGradientMode.Gradient;
        color.gradient = gradient;

        //Assign the color to particle
        ParticleSystem.ColorOverLifetimeModule COLM1 = curtain1.GetComponent<ParticleSystem>().colorOverLifetime;
        COLM1.color = color;
        ParticleSystem.ColorOverLifetimeModule COLM2 = curtain1.GetComponent<ParticleSystem>().colorOverLifetime;
        COLM2.color = color;
    }
    // Update is called once per frame
    //void Update()
    //{
    //    if (ring.activeSelf && ring.GetComponent<ParticleSystem>().isStopped)
    //    {
    //        ring.SetActive(false);
    //    }
    //}
    void RingEffect()
    {
        if (ring.activeSelf && ring.GetComponent<ParticleSystem>().isStopped)
        {
            ring.SetActive(false);
        }
        ring.SetActive(true);
    }
    void HitEffect()
    {
        if (hit.activeSelf && hit.GetComponent<ParticleSystem>().isStopped)
        {
            hit.SetActive(false);
        }
        hit.SetActive(true);
    }
}
