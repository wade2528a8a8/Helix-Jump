using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHelix : MonoBehaviour
{
    public  float speed;



    private void Update()
    {
        Rotate();
    }



    public void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            float rotx = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.up, -rotx);
        }
    }





}
