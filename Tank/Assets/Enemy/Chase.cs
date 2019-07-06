using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{

    public Transform target; // 追いかける対象
    public float rotMax; // 回転速度
    public float speed; // 移動スピード

    // 「OnTriggerStay」はトリガーが他のコライダーに触れている間中実行されるメソッド（ポイント）
    void OnTriggerStay(Collider other)
    {

        // もしも他のオブジェクトに「Player」というTag（タグ）が付いていたならば（条件）
        if (other.CompareTag("Battery"))
        {
            Debug.Log("chase");
            // 「root」を使うと「親（最上位の親）」の情報を取得することができる（ポイント）
            // LookAt()メソッドは指定した方向にオブジェクトの向きを回転させることができる（ポイント）
            //transform.root.LookAt(target);
            // ターゲット方向のベクトルを求める
            Vector3 vec = target.position - transform.position;

            // ターゲットの方向を向く
            transform.root.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), rotMax);
            transform.root.Translate(Vector3.forward * speed); // 正面方向に移動
        }
    }

}


