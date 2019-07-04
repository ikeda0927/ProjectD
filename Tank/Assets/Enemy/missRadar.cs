using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missRadar : MonoBehaviour
{

    public Transform target;
    //Transform tanktransform;
    //public void Start()
    //{
    //     tanktransform = GameObject.Find("Tank").transform;

    // 「OnTriggerStay」はトリガーが他のコライダーに触れている間中実行されるメソッド（ポイント）
    void OnTriggerStay(Collider other)
    //void Update()
    {
        //Vector3 forward = tanktransform.position - transform.position;

        // もしも他のオブジェクトに「Player」というTag（タグ）が付いていたならば（条件）
        if (other.gameObject.tag == "Battery")
        //if (gameObject.tag == "Battery")
        {
            Debug.Log("enemy");
            // 「root」を使うと「親（最上位の親）」の情報を取得することができる（ポイント）
            // LookAt()メソッドは指定した方向にオブジェクトの向きを回転させることができる（ポイント）
            transform.root.LookAt(target);
            //tankのtransformを取得
            

            // カメラに向かう方向を計算
           
            //if (forward != Vector3.zero) // 零ベクトルでない
            //{
                // カメラの向きを正面とする回転を作成して適用
                //transform.rotation = Quaternion.LookRotation(forward);
            //}
        }
    }
}