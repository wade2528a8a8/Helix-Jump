using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRing : MonoBehaviour
{
    private Helix[] helixes;
    private int count;
    private new MeshCollider collider;
    //添加力的數值
    private float forceValue = 300f;

    private Transform helixRingparent;

    private void Start()
    {
        helixes = this.GetComponentsInChildren<Helix>();
        collider = GetComponent<MeshCollider>();
        count = helixes.Length;
    }

    //碰到ring trigger 時
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {
            BreakHelixRing();

            GameManager.Instance.AddScore();
            collider.enabled = false;
            SoundManager.Instance.PlayHelixBreak();
        }

    }

    public void BreakHelixRing()
    {
        //添加外力
        for (int i = 0; i < count; i++)
        {
            helixes[i].AddForce(forceValue);

        }
        helixRingparent = gameObject.transform.GetComponentInParent<Transform>();
        
        Destroy(gameObject, 1f);
        
    }



}
