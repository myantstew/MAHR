using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using GooglePlayGames.BasicApi.SavedGame;

public class scr_loginScript : MonoBehaviour 
{
    public scr_saveGame saveGame;
    public Button loginButton;
    public Sprite buttonPressed;
    public Sprite fail;

	// Use this for initialization
	void Start () 
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    saveGame.LoadData();
                    SceneManager.LoadScene("scene_openCurtains");
                }
                else
                {
                    //loginButton.image.sprite = fail;
                    saveGame.LoadData();
                    Debug.Log("failed to login");
                }
            });
	}
	
	// Update is called once per frame
	public void Login () 
    {
        loginButton.image.sprite = buttonPressed;
        Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    saveGame.LoadData();
                    SceneManager.LoadScene("scene_openCurtains");
                }
                else
                {
                    loginButton.image.sprite = fail;
                    saveGame.LoadData();
                    Debug.Log("failed to login");
                }
            });
	}

    public void Skip()
    {
        SceneManager.LoadScene("scene_level0");
    }
}
