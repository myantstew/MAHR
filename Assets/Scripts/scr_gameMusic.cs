using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_gameMusic : MonoBehaviour 
{
    static bool AudioBegin = false;
    AudioSource myAudio;
    public AudioClip[] myClips;

	// Use this for initialization
	void Awake () 
    {
        myAudio = GetComponent<AudioSource>();

        if (!AudioBegin)
        {
            myAudio.clip = myClips[0];
            myAudio.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
	}

    public void ChangeMusic(int myMusic) 
    {
        if (myMusic == 0)
        {
            myAudio.Stop();
            myAudio.clip = myClips[0];
            myAudio.Play();
        }
        else if (myMusic == 1)
        {
            myAudio.Stop();
            myAudio.clip = myClips[1];
            myAudio.Play();
        }

	}
}
