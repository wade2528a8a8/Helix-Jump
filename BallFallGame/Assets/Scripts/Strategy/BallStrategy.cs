using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStrategy
{
    protected Rigidbody rb;
    public float reboundForce;
    public const float GlobalGravity = -9.8f;
    public float gravityScale = 1.0f;
    public bool Isforce { get; set; }
    public float RequiredVelocity { get; set; }

    private HelixRing helixRing;


    public void Fall()
    {
        Vector3 gravity = GlobalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
    public void Rebound()
    {
        Isforce = false;
        rb.velocity = Vector3.up * reboundForce;
        SoundManager.Instance.PlayBallRebound();
    }

    public void CheckIsforce()
    {
        if (Isforce)
        {
            Rebound();
        }

    }


}
