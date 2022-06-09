using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SplitCannonBall : CannonBall
{

    private static readonly int specialAvailableHash = Animator.StringToHash("SpecialAvailable");
    private static readonly int specialUsedHash = Animator.StringToHash("SpecialUsed");

    public float slitTime = 0.7f;
    public float splitAngle = 20.0f;
    public CannonBall splitCannonBallPrefeb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slitTime -= Time.deltaTime;

        if(slitTime <= 0)
        {
            SpawSplitCannonBalls();
        }
    }


    

    private void SpawSplitCannonBalls()
    {
        //set the spawn position and the forward direction of the connonballs
        var position = transform.position;
        var forward = cannonBallRigidBody.velocity;


        // set the forward direction of the split cannon balls
        var ball1Forward = Quaternion.AngleAxis(-splitAngle,Vector3.up) * forward;
        var ball2Forward = Quaternion.AngleAxis(splitAngle,Vector3.up) * forward;

        //instantiate the split cannon balls
        var ball1 = Instantiate(splitCannonBallPrefeb, position, Quaternion.identity);
        var ball2 = Instantiate(splitCannonBallPrefeb, position, Quaternion.identity);


        ball1.SetUp(ball1Forward);
        ball2.SetUp(ball2Forward);
        //trigger the special used animation
        cannonBallAnimator.SetTrigger(specialUsedHash);
        enabled = false;


    }

    public override void SetUp(Vector3 firForce)
    {
        base.SetUp(firForce);

        cannonBallAnimator.SetTrigger(specialAvailableHash);

    }
}
