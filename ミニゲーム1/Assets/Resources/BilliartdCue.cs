using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliartdCue : MonoBehaviour
{
    // Start is called before the first frame update
    bool keyJudge = true;
    bool shot = false;
    int shotCounter = 0;
    const int shotWeight = 40;
    const float WEIGHT = 0.2f;
    public float force = 450f;
    private static bool collisionJudge = false;
    private static int collisionCounter = 0;
    private const int COLLISION_WEIGHT = 5;
    private const float MOVE_WEIGHT = .1f;
    private static Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //ファール判定
        if (collision.transform.tag != "Ball" && collision.transform.tag != "Untagged")
        {
            Debug.Log("Collision detected on BilliardCue.cs : " + collision.transform.tag);
            //Debug.Break();
            Main.SetIsFoul();
        }

        //衝突検知(FixedUpdateのなかで以下の値を使う)
        collisionJudge = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || UI_Controler.GetPush())
        {
            if (keyJudge)
            {
                keyJudge = false;
                UI_Controler.StopPush();
                Hole.SetHoleIsTrigger();

                //上に動かす代わりにBoxColliderを無効にする
                gameObject.GetComponent<BoxCollider>().enabled = true;

                rb.AddRelativeForce(new Vector3(Mathf.Sin(gameObject.transform.localRotation.x * Mathf.Deg2Rad) * force, Mathf.Cos(gameObject.transform.localRotation.y * Mathf.Deg2Rad) * force, 0), ForceMode.Impulse);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || UI_Controler.GetMoveLeft())
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || UI_Controler.GetChangeAngle())
            {
                //Cueを回転させる
                rb.rotation = Quaternion.Euler(90, rb.rotation.eulerAngles.y - 1, 0);
            }
            else
            {
                //Cueの位置を変える
                rb.position = new Vector3(rb.position.x - MOVE_WEIGHT, rb.position.y, rb.position.z);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || UI_Controler.GetMoveRight())
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || UI_Controler.GetChangeAngle())
            {
                rb.rotation = Quaternion.Euler(90, rb.rotation.eulerAngles.y + 1, 0);
            }
            else
            {
                rb.position = new Vector3(rb.position.x + MOVE_WEIGHT, rb.position.y, rb.position.z);
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow) || UI_Controler.GetMoveFoward())
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z + MOVE_WEIGHT);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || UI_Controler.GetMoveBack())
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z - MOVE_WEIGHT);
        }
        else
        {
            keyJudge = true;
        }
        if (collisionJudge && collisionCounter < COLLISION_WEIGHT)
        {
            collisionCounter++;
        }
        else if (collisionJudge)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            collisionJudge = false;
            collisionCounter = 0;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
        //moveLeft = false;
        //moveRight = false;
        //moveFoward = false;
        //moveBack = false;
        //changeAngle = false;
    }
}
