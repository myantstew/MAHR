using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_sack : MonoBehaviour 
{
    public AudioClip myClip;
    public GameObject[] myPrize;

    Animator anim;
    Rigidbody2D mySack;
    AudioSource myAudioSource;
   
    Vector2 myThrow;
    float startPos;
    bool amIopen;

	// Use this for initialization
	void Start () 
    {
        myAudioSource = GetComponent<AudioSource>();
        mySack = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myThrow = new Vector2(50f, 125f);
        mySack.AddForce(myThrow);
        amIopen = false;
        startPos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(transform.position.y < startPos && amIopen == false)
            OpenSack();
        if (transform.position.y < -4)
            Destroy(this.gameObject);
	}
    void OpenSack()
    {
        myAudioSource.clip = myClip;
        myAudioSource.Play();
        int rdm = Random.Range(0, 6);
        amIopen = true;
        anim.SetBool("amIopen", true);
        Vector2 pop = new Vector2(0f, 100f);
        mySack.AddForce(pop);
        GameObject prize = Instantiate(myPrize[rdm], transform.position, transform.rotation)as GameObject;
    }
}
