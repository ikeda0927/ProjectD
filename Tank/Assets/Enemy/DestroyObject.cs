using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    //public GameObject effectPrefab;

    // ★★追加
    // 2種類目のエフェクトを入れるための箱
    //public GameObject effectPrefab2;

    // ★★追加
    public int objectHP;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            Debug.Log("hit");
            // ★★追加
            // オブジェクトのHPを１ずつ減少させる。
            objectHP -= 1;

            // ★★追加
            // もしもHPが0よりも大きい場合には（条件）
            /*if (objectHP > 0)
            {
                Destroy(other.gameObject);
                GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 2.0f);

            }
            else
            { // ★★追加  そうでない場合（HPが0以下になった場合）には（条件）
                Destroy(other.gameObject);

                // もう１種類のエフェクを発生させる。
                GameObject effect2 = (GameObject)Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);

                Destroy(this.gameObject);
            }
            */
            if (objectHP <= 0) {
                Debug.Log("Destroy");
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}