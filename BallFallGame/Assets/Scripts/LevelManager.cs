using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance{get;set;}
    public GameObject helixRing;
    public GameObject normalhelix;
    public GameObject redhelix;
    private float helixRingYPos=-10;

    public Helix[] helixes;
    public int[] randomArray;

    public GameObject cylinder;
    public GameObject cylinderParent;
    public float cylinderYPos=-13.5f;

    public int level=0;
    public int levelCount;
    public GameObject player;
    private float cylinderCenter =-3f;
    public Material redMat;


    public GameObject ironBall;
    public GameObject flutteringBall;

    private GameObject helixRingGo;



    private void Start()
    {
        Instance = this;
       //CreateMainCylinder();
    }
    private void Update()
    {
        if (player.transform.localPosition.y< cylinderCenter)
        {
            CreateMainCylinder();

            levelCount++;
            cylinderCenter -= 10f;

        }
        if (levelCount>=5)
        {
            if (level!=3)
            {
                level++;
                
            }
            levelCount = 0;
        }

    }

    public void CreateHelixRing()
    {
        
        helixRingGo = Instantiate(helixRing,this.transform);
        helixRingGo.transform.localPosition = new Vector3(0,helixRingYPos,0);
        helixRingYPos -= 2;
        helixes = helixRingGo.GetComponentsInChildren<Helix>();
        for (int i = 0; i < 12; i++)
        {
            helixes[i].gameObject.SetActive(false);
        }
        int randomPiecesCount = 0;
        switch (level)
        {
            case 0:
                randomPiecesCount = UnityEngine.Random.Range(9, 12);
                randomArray = new int[randomPiecesCount];
                SelectPiecesArray(randomPiecesCount);
                for (int i = 0; i < randomArray.Length - 1; i++)
                {
                    helixes[randomArray[i]].gameObject.SetActive(true);
                }
                break;
            case 1:
                randomPiecesCount = UnityEngine.Random.Range(8, 11);
                randomArray = new int[randomPiecesCount];
                SelectPiecesArray(randomPiecesCount);
                for (int i = 0; i < randomArray.Length-1; i++)
                {
                    int redRandom = UnityEngine.Random.Range(0, 4);
                    bool isRed=false;
                    if (redRandom ==0)
                    {
                        isRed = true;
                    }
                    if (isRed)
                    {
                        helixes[randomArray[i]].gameObject.tag = Tags.redHelix;
                        helixes[randomArray[i]].gameObject.GetComponent<Renderer>().material = redMat;

                    }
                    helixes[randomArray[i]].gameObject.SetActive(true);
                }
                
                break;
            case 2:
                randomPiecesCount = UnityEngine.Random.Range(7, 9);
                randomArray = new int[randomPiecesCount];
                SelectPiecesArray(randomPiecesCount);
                for (int i = 0; i < randomArray.Length - 1; i++)
                {
                    int redRandom = UnityEngine.Random.Range(0, 4);
                    bool isRed = false;
                    if (redRandom == 0||redRandom==1)
                    {
                        isRed = true;
                    }
                    if (isRed)
                    {
                        helixes[randomArray[i]].gameObject.tag = Tags.redHelix;
                        helixes[randomArray[i]].gameObject.GetComponent<Renderer>().material = redMat;

                    }
                    helixes[randomArray[i]].gameObject.SetActive(true);
                }
                break;
            case 3:
                randomPiecesCount = UnityEngine.Random.Range(6, 9);
                randomArray = new int[randomPiecesCount];
                SelectPiecesArray(randomPiecesCount);
                for (int i = 0; i < randomArray.Length - 1; i++)
                {
                    int redRandom = UnityEngine.Random.Range(0, 4);
                    bool isRed = false;
                    if (redRandom == 0 || redRandom == 1||redRandom==2)
                    {
                        isRed = true;
                    }
                    if (isRed)
                    {
                        helixes[randomArray[i]].gameObject.tag = Tags.redHelix;
                        helixes[randomArray[i]].gameObject.GetComponent<Renderer>().material = redMat;

                    }
                    helixes[randomArray[i]].gameObject.SetActive(true);
                }

                break;
            default:
                break;
        }


    }



    public void CreateMainCylinder()
    {
        GameObject cylinderGo = Instantiate(cylinder,cylinderParent.transform);
        cylinderGo.transform.localPosition = new Vector3(0, cylinderYPos, 0);
        cylinderYPos -= 10;
        int randomBall = UnityEngine.Random.Range(0, 4);
        for (int i = 0; i < 5; i++)
        {
            
            if (level >= 1&&i==2&&randomBall==0)
            {
                int random = UnityEngine.Random.Range(0, 2);
                if (random == 0)
                {
                    GameObject go = Instantiate(ironBall, this.transform);
                    go.transform.GetChild(0).transform.localPosition = new Vector3(0, helixRingGo.transform.position.y+1, -1.45f);
                    float ringDegree = UnityEngine.Random.Range(0, 361f);
                    Debug.Log(ringDegree);
                    go.transform.Rotate(Vector3.up,ringDegree);
                }
                else
                {
                    GameObject go = Instantiate(flutteringBall,this.transform);
                    go.transform.GetChild(0).transform.localPosition = new Vector3(0, helixRingGo.transform.position.y + 1, -1.45f);
                    float ringDegree = UnityEngine.Random.Range(0, 361) ;
                    Debug.Log(ringDegree);
                    go.transform.Rotate(Vector3.up , ringDegree);
                }

            }
            CreateHelixRing();
        }
      
        

    }

    public void SelectPiecesArray(int piecesCount)
    {
        for (int i = 0; i < piecesCount; i++)
        {
            randomArray[i] = UnityEngine.Random.Range(0, 13);
            for (int j = 0; j < i; j++)
            {
                while (randomArray[j] == randomArray[i])
                {
                    j = 0;
                    randomArray[i] = UnityEngine.Random.Range(1, 13);
                }
            }
        }
        Array.Sort(randomArray); 
    }







}
