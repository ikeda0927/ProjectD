using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    // Start is called before the first frame update
    static Transform target;
    [SerializeField] LineRenderer line;

    float maxTime = 5;
    int power;

    private List<Vector3> positions = new List<Vector3>();
    private Vector3 presposition = Vector3.zero;
    private Quaternion preBarrelRotation = Quaternion.identity;
    private Quaternion preBatteryRotation = Quaternion.identity;
    private int prePower = -1;

    private Transform startPosition;

    static bool judge;
    void Start()
    {
        power = Tank.GetPower();
        startPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.U))
        {
            SetTrailJudge(true);
            Debug.Log("target judge is true");
        }
        if (!judge)
        {
            Physics.autoSimulation = true;
            return;
        }

        Physics.autoSimulation = false;
        Debug.Log("target autoSimulation false");

        //((Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(Tank.GetBallSetPosition().x)) > 10) || (Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(Tank.GetBallSetPosition().y)) > 10) || (Mathf.Abs(Mathf.Abs(transform.position.z) - Mathf.Abs(Tank.GetBallSetPosition().z)) > 10))
        //if ( presposition == transform.position && preBarrelRotation == Tank.GetBarrelRotation() && preBatteryRotation == Tank.GetBatteryRotation())
        //return;

        if (target == null)
        {
            target = Tank.MakeBullet().transform;
            Debug.Log("target generated");
        }
        presposition = transform.position;
        preBarrelRotation = Tank.GetBarrelRotation();
        preBatteryRotation = Tank.GetBatteryRotation();

        positions.Clear();
        ResetRigidbody();

        AddForce();

        ProgressSimulate();
        line.positionCount = positions.Count;
        //positions.ToArray().GetValue(positions.Count);
        line.SetPositions(positions.ToArray());
        line.endColor = Color.red;
    }
    //void Simulate()
    //{
    //    List<Vector3> points = new List<Vector3>();
    //    Physics.Simulate()
    //}
    private void OnDisable()
    {
        Physics.autoSimulation = true;
        ResetRigidbody();
    }

    private void AddForce()
    {
        var rig = target.GetComponent<Rigidbody>();
        //rig.AddRelativeForce(new Vector3(0, -1, 0) * power, ForceMode.Impulse);
        //rig.AddForce(new Vector3(1, 1, 0) * power, ForceMode.Impulse);
        rig.AddExplosionForce(power, Tank.GetExplosionPosition(), 5f);
    }

    private void ProgressSimulate()
    {
        float time = 0;
        float deltaTime = Time.fixedDeltaTime;
        Vector3 lastPositions = new Vector3();
        while (time < maxTime)
        {

            if (target.position.y > 0.6f)
            {
                Physics.Simulate(deltaTime);
                time += deltaTime;

                positions.Add(target.position);
                lastPositions = target.position;
            }
            else
            {
                time += deltaTime;
                positions.Add(lastPositions);
            }
        }
    }
    void ResetRigidbody()
    {
        if (target != null)
        {
            target.position = Tank.GetBallSetPosition();
            target.rotation = Tank.GetBarrelRotation();
            var rig = target.GetComponent<Rigidbody>();
            rig.velocity = Vector3.zero;
            rig.angularVelocity = Vector3.zero;
        }
        //Destroy(target.gameObject);
    }
    public static void SetTrailJudge(bool b)
    {
        judge = b;
        Tank.SetTanKinematic(b);
        Target.SetKinematic(b);
        if (!b && target != null)
            Destroy(target.gameObject);
    }
}