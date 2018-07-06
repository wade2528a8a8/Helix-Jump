using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlutteringBall : BallStrategy
{
    public FlutteringBall(Rigidbody rb)
    {
        this.rb = rb;
        gravityScale = 1f;
        reboundForce = 6f;
        RequiredVelocity = 10f;

    }


}
