using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_sign : MonoBehaviour {

    Animator anim;
    public float raiseMe;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        StartCoroutine("RaiseSign");
	}
	
	// Update is called once per frame
    IEnumerator RaiseSign()
    {
        yield return new WaitForSeconds(raiseMe);
        anim.enabled = true;
    }
}
