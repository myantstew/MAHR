using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_particle : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        StartCoroutine("MyDeath");
	}
	
    IEnumerator MyDeath()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
