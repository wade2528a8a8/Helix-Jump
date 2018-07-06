using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBall : BallStrategy {

    public NormalBall(Rigidbody rb)
    {
        this.rb = rb;
        gravityScale = 1;
        reboundForce = 5f;
        RequiredVelocity = 11f;
        
    }


}
