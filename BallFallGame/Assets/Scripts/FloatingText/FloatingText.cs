using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public Animator ani;
    private Text floatingText;

    private void Awake()
    {
        floatingText = ani.GetComponent<Text>();

    }
    private void Start()
    {
        AnimatorClipInfo[] clipInfo = ani.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        
    }

    public void SetText(string text)
    {
        floatingText.text =text;
    }

}
