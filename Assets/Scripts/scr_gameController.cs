using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_gameController : MonoBehaviour 
{
    public static int LIVES;
    public static int SCORE;
    public static int COINS;
    public static bool HASPIG;
    public static int LIFEBANK;

    //public Text livesText;
    //public Text coinText;
    //public Text scoreText;

    public Text livesDataText;
    public Text coinDataText;
    public Text scoreDataText;
    public Text lifeBankText;

    public static bool firstPlay = true;

	// Use this for initialization
	void Start () 
    {
        if (firstPlay)
        {
            LIVES = 3;
            COINS = 0;
            firstPlay = false;
        }
        SCORE = 0;

        HASPIG = false;

        if (LIFEBANK < 3 && !scr_lifeTimer.isCounting)
            scr_lifeTimer.StartTimer();
        
        DontDestroyOnLoad(this.gameObject);
	}

    void Update()
    {
        if(lifeBankText)
        lifeBankText.text = LIFEBANK.ToString();
        if(livesDataText)
        livesDataText.text = LIVES.ToString();
        if(scoreDataText)
        scoreDataText.text = SCORE.ToString();
        if(coinDataText)
        coinDataText.text = COINS.ToString();


        if (LIVES < 0)
            LIVES = 0;
    }

    public static void GAMEOVER()
    {
        SceneManager.LoadScene("scene_gameOver");
    }

    public void EndGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("scene_intro");
    }
    public void Options()
    {
        SceneManager.LoadScene("scene_options");
    }
    public void Store()
    {
        SceneManager.LoadScene("scene_store");
    }
    public void Achievements()
    {
        SceneManager.LoadScene("scene_intro");
    }
    public void Leaderboard()
    {
        SceneManager.LoadScene("scene_intro");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("scene_intro");
    }
    public void Credits()
    {
        SceneManager.LoadScene("scene_intro");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("scene_intro");
    }
}
