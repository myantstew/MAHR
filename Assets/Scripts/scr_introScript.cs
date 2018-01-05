using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_introScript : MonoBehaviour 
{

    public GameObject leftEgg;
    public GameObject rightEgg;
    public GameObject explosion;
    public GameObject logo;

    public GameObject musicBox;

    public Canvas myCanvas;
    bool moveButton;

    Rigidbody2D myRigidbody;
    SpriteRenderer myColor;
    public Sprite farm;
    float blackLevel;

    public string myName;

	// Use this for initialization
	void Start () 
    {
        
        if (myName == "bg")
            myColor = GetComponent<SpriteRenderer>();
        if (myName == "leftEgg" || myName == "rightEgg")
            myRigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine("BreakEgg");
        if (myName == "leftEgg")
            EggFly("left");
        else if (myName == "rightEgg")
            EggFly("right");
        else if (myName == "bg")
        {
            myCanvas.enabled = false;
            StartCoroutine("BeginFade");
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
                    
	}

    void EggFly(string dir)
    {
        Vector2 leftForce = new Vector2(-10, 10);
        Vector2 rightForce = new Vector2(10, 10);
        if (dir == "left")
            myRigidbody.AddForce(leftForce, ForceMode2D.Impulse);
        else if (dir == "right")
            myRigidbody.AddForce(rightForce, ForceMode2D.Impulse);
    }
    IEnumerator BeginFade()
    {
        blackLevel = 1;
        yield return new WaitForSeconds(3);
        InvokeRepeating("BackgroundFade", 0.15f, 0.15f);
    }

    void BackgroundFade()
    {
            if (blackLevel <= 0)
            {
                blackLevel = 0;
                myColor.color = new Color(0f,0f,0f);
                CancelInvoke();
                myColor.sprite = farm;
                InvokeRepeating("NewBackground", 0.15f, 0.15f);
            }
            else
            {
                blackLevel -= 0.25f;
                myColor.color = new Color(blackLevel, blackLevel, blackLevel);
                if(!GameObject.FindWithTag("musicbox"))
                 {
                    GameObject newMusicBox = Instantiate(musicBox, transform.position, transform.rotation);
                 }
            }
    }
    void NewBackground()
    {
        if (blackLevel >= 1)
        {
            blackLevel = 1;
            myColor.color = new Color(1f,1f,1f);
            CancelInvoke();
            myCanvas.enabled = true;

        }
        else
        {
            blackLevel += 0.15f;
            myColor.color = new Color(blackLevel, blackLevel, blackLevel);
        }
    }
    IEnumerator BreakEgg()
    {
        Vector3 baseVector = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(3f);
        if (myName == "firstEgg")
        {
            GameObject left = Instantiate(leftEgg, baseVector, transform.rotation) as GameObject;
            GameObject right = Instantiate(rightEgg, baseVector, transform.rotation) as GameObject;
            GameObject explode = Instantiate(explosion, baseVector, transform.rotation) as GameObject;
            GameObject myLogo = Instantiate(logo, baseVector, transform.rotation) as GameObject;
            Destroy(this.gameObject);
        }

    }

    public void StartGame()
    {
        if (scr_gameController.LIFEBANK >= 3)
        {
            scr_gameController.LIVES = 3;
            scr_gameController.LIFEBANK -= 3;
        }
        else if(scr_gameController.LIFEBANK > 0 && scr_gameController.LIFEBANK <3)
        {
            scr_gameController.LIVES += scr_gameController.LIFEBANK;
            scr_gameController.LIFEBANK -= scr_gameController.LIFEBANK;
        }
        if(scr_gameController.LIVES > 0)
            SceneManager.LoadScene("scene_openCurtains");
        else
            NoLives();
    }

    public void Options()
    {
        SceneManager.LoadScene("scene_options");
    }

    public void NoLives()
    {
        SceneManager.LoadScene("scene_nolives");
    }
}
