using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class scr_enemyGenerator : MonoBehaviour {

	public GameObject mike;
	public GameObject sam;
	public GameObject rover;
	public GameObject willie;
    public GameObject santy;
    public GameObject rocketWillie;
    public GameObject willieCopter;
    public GameObject bob;
	public GameObject coin;

    private GameObject myBob;

    public GameObject player;
	public int myScore;
	float coyoteFreq = 100f;
    float coinFreq = 10f;

	public bool speed1, speed2, speed3, speed4, speed5, speed6, speed7, speed8;

	public AudioClip crow;

    // Use this for initialization
	void Start () 
	{
        InvokeRepeating ("CreateSam", 2f, 10);
        InvokeRepeating ("CreateSanty", 15f, 30);
        InvokeRepeating ("CreateMike", 60f, 25);
        InvokeRepeating ("CreateBob", 30f, 30);
        InvokeRepeating ("CreateRover", 120f, 45);
        InvokeRepeating ("CreateWillie", 480f, 90);
        InvokeRepeating ("CreateWillieCopter", 5f, 10);
        InvokeRepeating ("CreateRocketWillie", 360f, 60);
        InvokeRepeating ("CreateCoin", 5f, coinFreq);
	}
	
	// Update is called once per frame
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
        Vector2 offScreen = new Vector2 (-4.5f, height);
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

	/*void Update()
	{
		myScore = scr_scoreBoard.SCORE;

		if (myScore > 1500 && !speed2) 
		{
			speed2 = true;
			SpeedUp ();
		}
		if (myScore > 5000 && !speed3) 
		{
			speed3 = true;
			SpeedUp ();
		}
		if (myScore > 10000 && !speed4) 
		{
			speed4 = true;
			SpeedUp ();
		}
		if (myScore > 15000 && !speed5) 
		{
			speed5 = true;
			SpeedUp ();
		}
		if (myScore > 20000 && !speed6) 
		{
			speed6 = true;
			SpeedUp ();
		}
		if (myScore > 30000 && !speed7) 
		{
			speed7 = true;
			SpeedUp ();
		}
		if (myScore > 45000 && !speed8) 
		{
			speed8 = true;
			SpeedUp ();
		}


		if (Input.GetKeyDown (KeyCode.Escape)) 
			Application.Quit (); 
	}*/

	void SpeedUp()
	{
		//scr_Silo.GAMESPEED += 0.5f;
		Vector2 center = new Vector2 (0, 0);
		AudioSource.PlayClipAtPoint(crow, center);
	}
}
