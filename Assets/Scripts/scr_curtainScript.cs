using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr_curtainScript : MonoBehaviour 
{

    public string myName;
    public Canvas myCanvas;

    public bool curtainOpen;
    bool stopNow = false;
    bool raiseTop = false;
	// Use this for initialization

	void Start () 
    {
        StartCoroutine("StopAction");
        StartCoroutine("RaiseCurtain");
        myCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (myName == "outerCurtainOpen")
        {
            myCanvas.enabled = true;
        }    
        if (myName == "outerCurtain" && stopNow == false)
            {
                if (this.transform.localScale.x > 1)
                {
                    float x = transform.localScale.x - 0.025f;
                    Vector3 shrink = new Vector3(x, x, x);
                    transform.localScale = shrink;
                }
            }
        else if (myName == "outerCurtainOpen" && stopNow == true && raiseTop == true)
            {
                if (this.transform.localScale.x < 1.75f )
                {
                    float x = transform.localScale.x + 0.025f;
                    Vector3 shrink = new Vector3(x, x, x);
                    transform.localScale = shrink;
                }
            }
            else if (myName == "leftCurtain" && stopNow == false)
            {
                if (this.transform.position.x < -3.75f)
                {
                    float x = transform.position.x + 0.04f;
                    Vector3 close = new Vector3(x, transform.position.y, transform.position.z);
                    transform.position = close;
                }
            }
            else if (myName == "leftCurtainOpen" && stopNow == true)
            {
                if (this.transform.position.x > -8.5f)
                {
                    float x = transform.position.x - 0.04f;
                    Vector3 open = new Vector3(x, transform.position.y, transform.position.z);
                    transform.position = open;
                }   
            }
            else if (myName == "rightCurtain" && stopNow == false)
            {
                if (this.transform.position.x > 3.75f)
                {
                    float x = transform.position.x - 0.04f;
                    Vector3 close = new Vector3(x, transform.position.y, transform.position.z);
                    transform.position = close;
                }   
            }
            else if (myName == "rightCurtainOpen" && stopNow == true)
            {
                if (this.transform.position.x < 8.5f)
                {
                    float x = transform.position.x + 0.04f;
                    Vector3 open = new Vector3(x, transform.position.y, transform.position.z);
                    transform.position = open;
                }   
            }
            else if (myName == "gameOver" && stopNow == false)
            {
                if (this.transform.position.y > 0f)
                {
                    float y = transform.position.y - 0.07f;
                    Vector3 close = new Vector3(transform.position.x, y, transform.position.z);
                    transform.position = close;
                }   
            }
            else if (myName == "startGame" && stopNow == true)
            {
                if (this.transform.position.y > 0f)
                {
                    float y = transform.position.y - 0.07f;
                    Vector3 close = new Vector3(transform.position.x, y, transform.position.z);
                    transform.position = close;
                }   
            }

	}
    IEnumerator StopAction()
    {
        yield return new WaitForSeconds(3f);
        myCanvas.enabled = true;
        stopNow = true;
    }
    IEnumerator RaiseCurtain()
    {
        yield return new WaitForSeconds(4.5f);
        raiseTop = true;
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        if(curtainOpen)
            Initiate.Fade("scene_level0",Color.black,2f);
    }

}
