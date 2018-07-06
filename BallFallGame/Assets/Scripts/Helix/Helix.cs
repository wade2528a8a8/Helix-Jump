using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HelixMode
{
    normal,
    red
}

public class Helix : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 vector;
    private new MeshCollider collider;
    private HelixMode helixMode;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<MeshCollider>();
        rb.isKinematic = true;
    }

    private void Start()
    {

        
       

    }
    private void Update()
    {
       
        
    }
    //添加外力
    public void AddForce(float forceValue)
    {
        vector = V3RotateAround(transform.up, new Vector3(0, 0, -1), 15f);
        collider.isTrigger = true;
        rb.isKinematic = false;

        rb.AddForce(vector * forceValue, ForceMode.Acceleration);

    }


    //計算向量
    public Vector3 V3RotateAround(Vector3 source, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        return q * source;
    }




}
