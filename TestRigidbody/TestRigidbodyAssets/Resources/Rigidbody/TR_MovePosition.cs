using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_MovePosition : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    const float force = 10f;
    public float weight = .5f;
    bool keyjudge = true;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    /*
        デフォルトの設定では、isKinematicが有効で、
        CollisionDetectionがContinuousSpeculativeに
        なっており、ここら辺の設定をInspectorタブから変更
        してみると、動作が変わってくるので試してみて
    */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (keyjudge)
            {
                //一回のキー押下で一回のみ呼ばれるようにするため
                keyjudge = false;

                //現在の位置から右にweight分移動
                rb.MovePosition(rb.position + Vector3.right * weight);
            }
        }
        else
        {
            keyjudge = true;
        }
    }
}
