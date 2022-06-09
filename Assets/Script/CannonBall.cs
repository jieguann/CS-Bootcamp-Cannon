using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CannonBall : MonoBehaviour
{
    protected Rigidbody cannonBallRigidBody;


    [SerializeField] protected Animator cannonBallAnimator;
    [SerializeField] private float explosionRadius = 10.0f;
    [SerializeField] private float explosionForce = 12.0f;
    [SerializeField] private float explosionModifier = 1.0f;

    private static readonly int exploded = Animator.StringToHash("Exploded");

    private void Awake()
    {
        cannonBallRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    public virtual void SetUp(Vector3 firForce)
    {
        cannonBallRigidBody.AddForce(firForce, ForceMode.Impulse);
        cannonBallRigidBody.angularVelocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        //rotate around the collisition cantact point
        transform.rotation = Quaternion.FromToRotation(transform.up, collision.GetContact(0).normal) * transform.rotation;

        //reset inerta, velocity, angular velocity etc =0
        cannonBallRigidBody.velocity = Vector3.zero;
        cannonBallRigidBody.angularVelocity = Vector3.zero;
        cannonBallRigidBody.isKinematic = true;

        //trigger the explosion
        cannonBallAnimator.SetTrigger(exploded);

        //Lesson 3 - Moar physics
        Vector3 explosionPosition = transform.position;

        
        Collider[] touchingColliders = Physics.OverlapSphere(explosionPosition, explosionRadius, LayerMask.GetMask("Targets"));

        foreach(Collider collider in touchingColliders)
        {
            Rigidbody colliderRigibody = collider.GetComponent<Rigidbody>();
            if(colliderRigibody != null)
            {
                colliderRigibody.AddExplosionForce(
                    explosionForce, 
                    explosionPosition, 
                    explosionRadius, 
                    explosionModifier,
                    ForceMode.Impulse
                    );
            }

        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    public void OnFinishedExplosionAnimation()
    {
        Destroy(gameObject);
    }
}
