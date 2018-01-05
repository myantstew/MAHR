using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_buttonScript : MonoBehaviour 
{
    public scr_playerScript playerScript;

	// Use this for initialization
	void Start () 
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<scr_playerScript>();
	}
	
	// Update is called once per frame
	public void Jump() 
    {
        if (!playerScript)
            playerScript = GameObject.FindWithTag("Player").GetComponent<scr_playerScript>();
        playerScript.Jump();
	}
}
