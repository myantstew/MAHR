using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_pigpen : MonoBehaviour 
{
   Animator anim;
   AudioSource myAudio;

   public AudioClip myClip;
   public scr_playerScript playerScript;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
        playerScript = GetComponent<scr_playerScript>();
	}
	
	// Update is called once per frame
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<scr_playerScript>().hasPig == true)
        {
            myAudio.clip = myClip;
            myAudio.Play();
            scr_gameController.SCORE += 500;
            anim.SetBool("fullpen", true);
        }
	}
}
