using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{

    public Transform target;

    // 「OnTriggerStay」はトリガーが他のコライダーに触れている間中実行されるメソッド（ポイント）
    void OnTriggerStay(Collider other)
    {

        // もしも他のオブジェクトに「Player」というTag（タグ）が付いていたならば（条件）
        //if (other.CompareTag("Player"))
        //{

            // 「root」を使うと「親（最上位の親）」の情報を取得することができる（ポイント）
            // LookAt()メソッドは指定した方向にオブジェクトの向きを回転させることができる（ポイント）
            //transform.root.LookAt(target);

            //tankのtransformを取得
            Transform tanktransform = GameObject.Find("Tank").transform;

            // カメラに向かう方向を計算
            Vector3 forward = tanktransform.transform.position - transform.position;
            if (forward != Vector3.zero) // 零ベクトルでない
            {
                // カメラの向きを正面とする回転を作成して適用
                transform.rotation = Quaternion.LookRotation(forward);
            }
        //}
    }
}