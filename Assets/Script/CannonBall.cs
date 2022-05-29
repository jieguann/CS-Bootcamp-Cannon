using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private Rigidbody cannonBallRigidBody;

    private void Awake()
    {
        cannonBallRigidBody = GetComponent<Rigidbody>();
    }
    
    public void SetUp(Vector3 firForce)
    {
        cannonBallRigidBody.AddForce(firForce, ForceMode.Impulse);
        cannonBallRigidBody.angularVelocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
    }
}
