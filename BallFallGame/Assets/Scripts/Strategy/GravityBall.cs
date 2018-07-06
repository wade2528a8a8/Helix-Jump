using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBall : BallStrategy
{

    public GravityBall(Rigidbody rb)
    {
        this.rb = rb;
        gravityScale = 1.5f;
        reboundForce = 5f;
        RequiredVelocity = 8f;

    }


}