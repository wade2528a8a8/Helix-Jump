using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContext 
{
    public BallStrategy ballMode = null;

    public void SetMode(BallStrategy mode)
    {
        ballMode = mode;
    }

    public void Fall()
    {
        ballMode.Fall();
    }
    public void Rebound()
    {
        ballMode.Rebound();
    }

   
    public void CheckIsForce()
    {
        ballMode.CheckIsforce();
    }

	
}
