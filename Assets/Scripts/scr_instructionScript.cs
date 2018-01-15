using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class scr_instructionScript : MonoBehaviour 
{
    Image mainImage;
    public Sprite[] mySprites;
    int i;

	// Use this for initialization
	void Start () 
    {
        i = 0;
        mainImage = GetComponent<Image>();
        mainImage.sprite = mySprites[i];
	}
	
    public void Next()
    {
        if (i + 1 >= mySprites.Length)
            i = 0;
        else
            i = i + 1;
        mainImage.sprite = mySprites[i];
    }
    public void Back()
    {
        if (i - 1 < 0)
            i = mySprites.Length-1;
        else
            i = i - 1;
        mainImage.sprite = mySprites[i];
    }

    public void MainMenuReturn()
    {
        SceneManager.LoadScene("scene_intro");
    }
}
