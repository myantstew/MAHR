using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scr_splashScript : MonoBehaviour 
{

    scr_saveGame saveGame;
    bool isfading;

	// Use this for initialization
	void Start () 
    {
        saveGame = GetComponent<scr_saveGame>();
        StartCoroutine("StartScreen");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            saveGame.SaveData();
            Application.Quit();
        }
        else if(Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("scene_intro");
	}

    IEnumerator StartScreen()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("scene_intro");
    }
}
