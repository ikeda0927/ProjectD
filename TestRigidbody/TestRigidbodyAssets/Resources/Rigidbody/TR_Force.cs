using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_Force : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    bool keyJudge = true;
    public float force = 50f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    /*
    AddForce関数とAddRelativeForce関数の違いを簡単に表すと、
    AddForceはグローバルな座標を用い、
    AddRelativeForceはローカルな座標を用いているという違い。
    */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            //ForceModeがForceの場合はRigidbodyで設定された質量を考慮した力が与えられる。
            //力を与え続けるのに向いている。
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                //シフトを押しながらの場合はAddRelativeForce
                Debug.Log("AddRelativeForce:Force");
                rb.AddRelativeForce(Vector3.forward * force);
            }
            else
            {
                //他に何も押していない場合はAddForce
                Debug.Log("AddForce:Force");
                rb.AddForce(Vector3.forward * force);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //ForceModeがAccelerationの場合はRigidbodyで設定された質量を無視した力が与えられる。
            //力を与え続けるのに向いている。(押し続ける感じ)
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                //シフトを押しながらの場合はAddRelativeForce
                Debug.Log("AddRelativeForce:Acceleration");
                rb.AddRelativeForce(Vector3.forward * force, ForceMode.Acceleration);
            }
            else
            {
                //他に何も押していない場合はAddForce
                Debug.Log("AddForce:Acceleration");
                rb.AddForce(Vector3.forward * force, ForceMode.Acceleration);
            }
        }
        else if (Input.GetKey(KeyCode.I))
        {
            //ForceModeがImpulseの場合はRigidbodyで設定された質量を考慮した力が与えられる。
            //一回のみ力を与えるのに向いている。(衝撃を加えるみたいな感じ)
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                //シフトを押しながらの場合はAddRelativeForce
                if (keyJudge)
                {
                    //一回のキー押下で一回のみ呼ばれるようにするため
                    keyJudge = false;
                    Debug.Log("AddRelativeForce:Inpulse");
                    rb.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
                }
            }
            else
            {
                //他に何も押していない場合はAddForce
                if (keyJudge)
                {
                    //一回のキー押下で一回のみ呼ばれるようにするため
                    keyJudge = false;
                    Debug.Log("AddForce:Impulse");
                    rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
                }
            }
        }
        else if (Input.GetKey(KeyCode.V))
        {
            //ForceModeがImpulseの場合はRigidbodyで設定された質量を無視した力が与えられる。
            //一回のみ力を与えるのに向いている。(衝撃を加えるみたいな感じ)
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                //シフトを押しながらの場合はAddRelativeForce
                if (keyJudge)
                {
                    //一回のキー押下で一回のみ呼ばれるようにするため
                    keyJudge = false;
                    Debug.Log("AddRelativeForce:VelocityChange");
                    rb.AddRelativeForce(Vector3.forward * force, ForceMode.VelocityChange);
                }
            }
            else
            {
                //他に何も押していない場合はAddForce
                if (keyJudge)
                {
                    //一回のキー押下で一回のみ呼ばれるようにするため
                    keyJudge = false;
                    Debug.Log("AddForce:VelocityChange");
                    rb.AddForce(Vector3.forward * force, ForceMode.VelocityChange);
                }
            }
        }
        else
        {
            keyJudge = true;
        }
    }
}
