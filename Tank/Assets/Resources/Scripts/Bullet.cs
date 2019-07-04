using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float force = 100f;//爆発の威力
    public float range = 5f;//爆発の範囲
    GameObject effect;
    ParticleSystem particle;
    bool particleJudge;
    bool collisionWithTarget;
    void Start()
    {
        effect = gameObject.transform.Find("SmallExplosionEffect").gameObject;
        particle = effect.GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.tag == "Target")
        if (collision.transform.tag != "Battery")
        {
            collisionWithTarget = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject != null && !particleJudge && gameObject.transform.position.y <= .8f) || collisionWithTarget)
        {
            Debug.Log("Explosion");
            Explosion();
        }
        else if (gameObject != null && particleJudge && !particle.isPlaying)
        {
            Destroy(gameObject);
        }


    }
    void Explosion()
    {
        particleJudge = true;
        effect.SetActive(true);
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //Bomb周辺(rangeの範囲)のオブジェクトを取得
        var others = Physics.OverlapSphere(gameObject.transform.position, range);
        foreach (Collider other in others)
        {
            //取得したオブジェクトのうち、タグが"Bomb"か"Block"だった場合、それらに爆発による力を加える
            if (other.tag == "Bullet" || other.tag == "Target" || other.tag == "Tank")
            {
                //第二引数は爆発の中心地点(この場合はBombの中心)
                other.GetComponent<Rigidbody>().AddExplosionForce(force, gameObject.transform.position, range);
            }
        }
    }
}
