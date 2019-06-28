using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float force = 100f;//爆発の威力
    public float range = 1f;//爆発の範囲
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Bomb周辺(rangeの範囲)のオブジェクトを取得
            var others = Physics.OverlapSphere(gameObject.transform.position, range);
            foreach (Collider other in others)
            {
                //取得したオブジェクトのうち、タグが"Bomb"か"Block"だった場合、それらに爆発による力を加える
                if (other.tag == "Bomb" || other.tag == "Block")
                {
                    //第二引数は爆発の中心地点(この場合はBombの中心)
                    other.GetComponent<Rigidbody>().AddExplosionForce(force, gameObject.transform.position, range);
                }
            }
            //Bomb自体を削除(爆発して無くなった感じにするため)
            Destroy(gameObject);
        }
    }
}
