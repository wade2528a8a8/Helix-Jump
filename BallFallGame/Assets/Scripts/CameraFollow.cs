using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float YMinMargin;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
       
    }
    private void Update()
    {
 
        Vector3 targetPos = target.position;
        if (transform.position.y-targetPos.y>YMinMargin)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, smoothTime*Time.deltaTime);

        }
    }




}
