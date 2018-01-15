using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class scr_enemyGenerator : MonoBehaviour 
{
	public GameObject mike;
	public GameObject sam;
	public GameObject rover;
	public GameObject willie;
    public GameObject santy;
    public GameObject rocketWillie;
    public GameObject willieCopter;
    public GameObject bob;
	public GameObject coin;
    public GameObject player;

    private GameObject myBob;

    public int targetScore = scr_gameController.TARGETSCORE;
    public static float GAMESPEED;
    public int myScore; 

	public float coyoteFreq = 15f;
    public float coinFreq = 6f;

    public scr_levelScript levelScript;

	public bool newLevel = false;

	void Start () 
	{
        GAMESPEED = -0.01f;
        InvokeRepeating ("CreateSam", 2f, 10);
        InvokeRepeating ("CreateSanty", 20f, 30);
        InvokeRepeating ("CreateCoin", 5f, coinFreq);
        InvokeRepeating ("CreateBob", 30f, 30);
    }
	
    void InitializeInvoke(int level)
    {
        switch(level)
        {
            case 3:
                {    
                    InvokeRepeating ("CreateSam", 2f, coyoteFreq);
                    InvokeRepeating("CreateMike", 5f, coyoteFreq);
                }
                break;
            case 5:
                {
                    InvokeRepeating("CreateRover", 5f, coyoteFreq + 8);
                    InvokeRepeating("CreateWillieCopter", 5f, coyoteFreq);
                }
                break;
            case 6:
                {
                    InvokeRepeating("CreateMike", 5f, coyoteFreq);
                    InvokeRepeating("CreateWillie", 5f, coyoteFreq + 3);
                }
                break;
            case 7:
                {
                    InvokeRepeating("CreateRover", 5f, coyoteFreq + 4);
                    InvokeRepeating("CreateMike", 5f, coyoteFreq);
                }
                break;
            case 8:
                {
                    InvokeRepeating ("CreateSam", 2f, coyoteFreq);
                    InvokeRepeating("CreateRocketWillie", 5f, coyoteFreq + 10);
                }
                break;
            default:
                break;
        }
    }

	void CreateSam () 
	{
		float height = Random.Range (-0.5f, 1.25f);
		Vector2 offScreen = new Vector2 (-4.5f, height);
		Instantiate (sam, offScreen, Quaternion.identity);
	}
    void CreateSanty () 
    {
        float height = Random.Range (-0.5f, 1.25f);
        Vector2 offScreen = new Vector2 (-4.5f, height);
        Instantiate (santy, offScreen, Quaternion.identity);
    }
    void CreateMike () 
    {
        float height = Random.Range (0f, 1.25f);
        Vector2 offScreen = new Vector2 (-4.5f, height);
        Instantiate (mike, offScreen, Quaternion.identity);
    }
    void CreateRover () 
    {
        float height = Random.Range (0f, 1.25f);
        Vector2 offScreen = new Vector2 (-4.5f, height);
        Instantiate (rover, offScreen, Quaternion.identity);
    }
    void CreateWillie () 
    {
        float height = Random.Range (0f, 1.25f);
        Vector2 offScreen = new Vector2 (4.5f, height);
        Instantiate (willie, offScreen, Quaternion.identity);
    }
    void CreateRocketWillie () 
    {
        float height = Random.Range (0f, 1.25f);
        Vector2 offScreen = new Vector2 (-4.5f, height);
        Instantiate (rocketWillie, offScreen, Quaternion.identity);
    }
    void CreateBob () 
    {
        float height = Random.Range (-2.5f, -3f);
        Vector2 offScreen = new Vector2 (-2.5f, height);
        myBob = GameObject.Find("bob(Clone)");
        if (scr_gameController.HASPIG == false && !myBob)
            Instantiate(bob, offScreen, Quaternion.identity);
    }
    void CreateCoin () 
    {
        float height = Random.Range (0f, 1.25f);
        Vector2 offScreen = new Vector2 (4f, height);
        Instantiate (coin, offScreen, Quaternion.identity);
    }
    void CreateWillieCopter () 
    {
        float height = Random.Range (-0.5f, 1.25f);
        Vector2 offScreen = new Vector2 (4.5f, height);
        Instantiate (willieCopter, offScreen, Quaternion.identity);
    }

	void Update()
    {
        myScore = scr_gameController.SCORE;
        if (myScore >= targetScore && !newLevel)
        {
            newLevel = true;
            LevelUp();
        }
        if (Input.GetKeyDown (KeyCode.Escape)) 
            Application.Quit (); 
    }

    void LevelUp()
    {
        targetScore = targetScore + 500;
        scr_gameController.MYLEVEL += 1;
        levelScript.ShowText();
        InitializeInvoke(scr_gameController.MYLEVEL);
        if (scr_gameController.MYLEVEL % 2 == 0)
        {
            if (GAMESPEED > -0.4f)
                GAMESPEED -= 0.0025f;
        }
        if(coyoteFreq >= 5)
            coyoteFreq -= 1;
        newLevel = false;
    }
}
