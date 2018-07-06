using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

    public static FloatingTextController Instance { get; set; }
    public  GameObject floatingText;
    private static GameObject canvas;
    public Transform floatingTextPanel;


    private  void Start()
    {
        Instance = this;
        canvas = GameObject.Find("Canvas");
        

    }
    public void CreateFloatingText(string text)
    {
        GameObject textGo = Instantiate(floatingText);
       
        textGo.transform.SetParent(floatingTextPanel);
        textGo.transform.localPosition = Vector3.zero;
        textGo.GetComponent<FloatingText>().SetText(text);


    }

	
}
