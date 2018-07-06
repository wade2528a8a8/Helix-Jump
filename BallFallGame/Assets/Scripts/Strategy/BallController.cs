using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private BallContext ball;
    private HelixRing helixRing;
    public  new Renderer renderer;
    public Material[] materials;
    public Color[] trailcolors;
    private TrailRenderer trailRenderer;

    private float modeTime;
    private void Start()
    {
        ball = new BallContext();
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        ball.SetMode(new NormalBall(rb));
        trailRenderer = GetComponent<TrailRenderer>();


    }
    private void Update()
    {
        ball.CheckIsForce();
        if (Time.time- modeTime>=10)
        {
            ball.SetMode(new NormalBall(rb));
            modeTime = 0;
            SetMode(0, 0, 0.3f);
        }
    }
    private void FixedUpdate()
    {
        ball.Fall();
    }


    private void OnCollisionEnter(Collision col)
    {
        ball.ballMode.Isforce= true;
        //力道不夠強，碰到紅色時遊戲結束
        if (col.relativeVelocity.y < ball.ballMode.RequiredVelocity)
        {

            if (col.collider.tag == Tags.redHelix)
            {
                Debug.Log("DEATH");
                Time.timeScale = 0;
                //TODO
                //重新畫面
                GameManager.Instance.GameOver();
    

            }
            else
            {
                return;
            }
        }
        else//如果力道夠強 直接摧毀
        {

            if (col.collider.tag == Tags.helixPiece || col.collider.tag == Tags.redHelix)
            {
                helixRing = col.gameObject.GetComponentInParent<HelixRing>();
                helixRing.BreakHelixRing();
            }

        }



    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag==Tags.ironBall)
        {
            modeTime = Time.time;
            ball.SetMode(new GravityBall(rb));
            SetMode(1, 1, 0.4f);
            Destroy(col.gameObject);
        }
        if (col.tag==Tags.flutteringBall)
        {
            modeTime = Time.time;
            ball.SetMode(new FlutteringBall(rb));
            SetMode(2, 2, 0.3f);
            //renderer.material = materials[2];
            //trailRenderer.material.SetColor("_EmisColor", trailcolors[2]);
            Destroy(col.gameObject);
        }
    }

    public void SetMode(int materialIndex,int trailcolorsIndex,float scale)
    {
        renderer.material = materials[materialIndex];
        trailRenderer.material.SetColor("_EmisColor", trailcolors[trailcolorsIndex]);
        transform.localScale = new Vector3(scale, scale, scale);

    }
}
