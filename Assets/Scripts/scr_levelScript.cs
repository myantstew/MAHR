using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_levelScript : MonoBehaviour 
{
    Animator anim;
    AudioSource myAudio;
    public AudioClip crow;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
        anim.SetBool("activated", false);
	}
	
	// Update is called once per frame
	public void ShowText () 
    {
        if (!anim.enabled)
            anim.enabled = true;
        
        anim.SetBool("activated", true);
        StartCoroutine("Reset");
	}

    public void Crowing()
    {
        myAudio.clip = crow;
        myAudio.Play();
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("activated", false);
    }
}
