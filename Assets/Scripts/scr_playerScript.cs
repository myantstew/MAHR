using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class scr_playerScript : MonoBehaviour 
{
    AudioSource myAudioSource;
    public AudioClip clipPowerUp;
    public AudioClip clipPowerUpCat;
    public AudioClip clipPowerUpHawk;
    public AudioClip clipPowerUpEel;
    public AudioClip clipPowerUpMudbug;
    public AudioClip clipPowerDown;
    public AudioClip clipCat;

    float speed = 2;
    Vector2 jumpForce = new Vector2(0,100f);
    Rigidbody2D player;
    Animator anim;
    Renderer myRenderer;
    SpriteRenderer myColor;
    int myArmor = 0;
    float alphaLevel = 1;
    float blackLevel = 1;
    float healTime;



    public GameObject pig;
    public GameObject myDeath;
    public GameObject roosterDeath;
    public GameObject mySmoke;

    public GameObject rock;
    public GameObject bolt;
    public GameObject splash;

    public bool hasPig = false;

    public bool iHasEel;
    public bool iHasMudbug;
    public bool iHasCat;
    bool canBeHit;

    public bool CanShoot = true;
    bool outOfBounds = false;

    public string myName;

	// Use this for initialization
	void Start () 
    {
        canBeHit = true;
        healTime = 2;
        player = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<Renderer>();
        myColor = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        if(myName != "firstMaurice")
            StartCoroutine("Damaged");
	}
	
	// Update is called once per frame
	void Update () 
    {        
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }

        player.velocity = new Vector2(CnInputManager.GetAxis("Horizontal")* speed, player.velocity.y);
        //if(Input.GetKeyDown("left"))
        //    MoveLeft();
        //if (Input.GetKeyDown("right"))
        //    MoveRight();

        if (Input.GetKeyDown(KeyCode.M) && CanShoot)
        {
            Debug.Log("I'm Shooting");
            Shoot();
        }
	}
    public void Jump()
    {
        anim.SetBool("jump", true);
        StartCoroutine("EndJumpAnim");
        player.AddForce(jumpForce);
        if (jumpForce.y > 200)
            jumpForce.y = 200;
    }

    public void Shoot()
    {
        if (CanShoot)
        {
            if (iHasEel)
            {
                Vector3 blastPosition = new Vector3(transform.position.x, 0, 0);
                GameObject myBolt = Instantiate(bolt, blastPosition, transform.rotation)as GameObject;
                CanShoot = false;
            }
            else if (iHasMudbug)
            {
                GameObject myRock = Instantiate(rock, transform.position, transform.rotation)as GameObject;
                CanShoot = false;
            }
            else if (iHasCat)
            {
                myAudioSource.clip = clipCat;
                myAudioSource.Play();
                GameObject mySplash = Instantiate(splash, transform.position, transform.rotation)as GameObject;
                Vector2 myPosition = new Vector2(3.25f, transform.position.y);
                Vector2 revPosition = new Vector2(-3.25f, transform.position.y);
                if (player.velocity.x < 0)
                {
                    transform.position = revPosition;
                    GameObject secondSplash = Instantiate(splash, transform.position, transform.rotation)as GameObject;
                }
                else
                {
                    transform.position = myPosition;
                    GameObject secondSplash = Instantiate(splash, transform.position, transform.rotation)as GameObject;
                }   
                CanShoot = false;
                StartCoroutine("Shadow");
            }
            StartCoroutine("ResetShot");
        }
    }

    public void MoveLeft()
    {
        player.velocity = new Vector2(-1 * speed, player.velocity.y);
    }
    public void MoveRight()
    {
        player.velocity = new Vector2(1 * speed, player.velocity.y);
    }
    IEnumerator EndJumpAnim()
    {
        yield return new WaitForSeconds(0.15f);
        anim.SetBool("jump", false);
    }

    public IEnumerator ResetShot()
    {
        if(iHasEel)
            yield return new WaitForSeconds(5);
        else if(iHasMudbug)
            yield return new WaitForSeconds(0.5f);
        else if(iHasCat)
            yield return new WaitForSeconds(10);
        CanShoot = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 13)
            Debug.Log("roosterHIT!");

        if (other.gameObject.tag == "enemy" && other.transform.position.y + 0.25f > this.transform.position.y && canBeHit)
        {
            canBeHit = false;
            ImHit();
        }
        
        if (other.gameObject.tag == "pig")
        {
            hasPig = true;
            scr_gameController.HASPIG = true;
            anim.SetBool("hasPig", true);
        }
        if(other.gameObject.tag =="coin")
            scr_gameController.COINS += 1;
        
        if(other.gameObject.tag =="dime")
            scr_gameController.COINS += 10;
        
        if(other.gameObject.tag =="quarter")
            scr_gameController.COINS += 25;
        
        if (other.gameObject.tag == "pigpen" && hasPig)
        {
            hasPig = false;
            scr_gameController.HASPIG = false;
            anim.SetBool("hasPig", false);
        }
        if (other.gameObject.tag == "cheese")
        {
            myArmor = 1;
            iHasEel = true;
            anim.SetBool("hasEel", true);
            iHasMudbug = false;
            anim.SetBool("hasMudbug", false);
            iHasCat = false;
            anim.SetBool("hasCat", false);
            StartCoroutine("Transformation");
        }
        if (other.gameObject.tag == "moth")
        {
            myArmor = 1;
            iHasEel = false;
            anim.SetBool("hasEel", false);
            iHasMudbug = true;
            anim.SetBool("hasMudbug", true);
            iHasCat = false;
            anim.SetBool("hasCat", false);
            StartCoroutine("Transformation");
        }
        if (other.gameObject.tag == "bulb")
        {
            myArmor = 1;
            iHasEel = false;
            anim.SetBool("hasEel", false);
            iHasMudbug = false;
            anim.SetBool("hasMudbug", false);
            iHasCat = true;
            anim.SetBool("hasCat", true);
            StartCoroutine("Transformation");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "boundary" && other.transform.position.x > this.transform.position.x)
            Die();
    }

    void ImHit()
    {
        myArmor -= 1;
        healTime = 5;
        if (myArmor < 0)
            Die();
        else if (myArmor == 0)
        {
            iHasEel = false;
            anim.SetBool("hasEel", false);
            iHasMudbug = false;
            anim.SetBool("hasMudbug", false);
            iHasCat = false;
            anim.SetBool("hasCat", false);
            StartCoroutine("Transformation");
        }
    }
    IEnumerator Transformation()
    {
        myRenderer.enabled = false;
        if (iHasEel)
        {
            myAudioSource.clip = clipPowerUpEel;
            myAudioSource.Play();
        }
        else if (iHasCat)
        {
            myAudioSource.clip = clipPowerUpCat;
            myAudioSource.Play();
        }
        else if (iHasMudbug)
        {
            myAudioSource.clip = clipPowerUpMudbug;
            myAudioSource.Play();
        }
        else if (myArmor == 0)
        {
            myAudioSource.clip = clipPowerDown;
            myAudioSource.Play();
            StartCoroutine("Damaged");
        }

        Instantiate(mySmoke, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        myRenderer.enabled = true;
    }

    IEnumerator Damaged()
    {
        canBeHit = false;
        InvokeRepeating("Flicker", 0.15f, 0.15f);
        yield return new WaitForSeconds(healTime);
        canBeHit = true;
    }

    void Flicker()
    {

        if (!canBeHit)
        {
            if (alphaLevel == 1)
                alphaLevel = 0.25f;
            else if (alphaLevel == 0.25f)
                alphaLevel = 1;
            myColor.color = new Color(1f,1f,1f,alphaLevel);
        }
        else if (canBeHit)
        {
            alphaLevel = 1;
            myColor.color = new Color(1f,1f,1f,alphaLevel);
            CancelInvoke();
        }
    }

    IEnumerator Shadow()
    {
        canBeHit = false;
        this.gameObject.layer = 14;
        blackLevel = 0;
        myColor.color = new Color(0f,0f,0f);
        yield return new WaitForSeconds(5);
       //myColor.color = Color.white;
        InvokeRepeating("FadeIn", 0.15f, 0.15f);
    }

    void FadeIn()
    {
        if (blackLevel >= 1)
        {
            blackLevel = 1;
            myColor.color = new Color(1f,1f,1f);
            canBeHit = true;
            this.gameObject.layer = 11;
            CancelInvoke();
        }
        else
        {
            blackLevel += 0.05f;
            myColor.color = new Color(blackLevel, blackLevel, blackLevel);
        }
    }

    void Die()
    {
        if (hasPig)
            Instantiate(pig, transform.position, transform.rotation);
        scr_gameController.HASPIG = false;
        GameObject Death = Instantiate(myDeath, transform.position, transform.rotation);
        GameObject chickenDeath = Instantiate(roosterDeath, transform.position, transform.rotation);
        scr_gameController.LIVES -= 1;
        Destroy(this.gameObject);
    }
}
