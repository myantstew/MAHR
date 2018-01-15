using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemyScript : MonoBehaviour 
{
    public Vector2 landerVelocity;
    public Vector2 coyoteVelocity;
    public Vector2 mikeVelocity;
    public Vector2 rocketVelocity;
    public Vector2 copterVelocity;
    float myAltitude;
    float myVertical = 0.75f;

    public GameObject pig;
    public GameObject sack;
    public GameObject myDeath;
    public GameObject myShock;
    public GameObject myVehicleDeath;
    public GameObject mutantPig;

    public string myName;

	// Use this for initialization
	void Start () 
    {
        landerVelocity = new Vector2(0.5f*Time.deltaTime, 0.5f*Time.deltaTime);
        coyoteVelocity = new Vector2(0.5f * Time.deltaTime, 0);
        rocketVelocity = new Vector2(1.5f * Time.deltaTime, 0);
        mikeVelocity = new Vector2(0.5f * Time.deltaTime, myVertical * Time.deltaTime);
        copterVelocity = new Vector2(1f * Time.deltaTime, myVertical * Time.deltaTime);
        myAltitude = transform.position.y;

        if (myName == "willie")
        {
            Vector3 myScale = new Vector3(-1, 1, 1);
            transform.localScale = myScale;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (myName == "bob")
        {
            transform.Translate(landerVelocity, 0);
            if (this.transform.position.y > 3)
            {
                GameObject mutant = Instantiate(mutantPig, transform.position, transform.rotation)as GameObject;
                Destroy(this.gameObject);
            }
        }
        else if (myName == "sam")
            transform.Translate(coyoteVelocity, 0);
        else if (myName == "santy")
            transform.Translate(coyoteVelocity, 0);
        else if (myName == "rover")
            transform.Translate(-coyoteVelocity, 0);
        else if (myName == "willie")
            transform.Translate(-coyoteVelocity*3f, 0);
        else if (myName == "rocketwillie")
            transform.Translate(rocketVelocity, 0);
        else if (myName == "coin")
            transform.Translate(-coyoteVelocity, 0);
        else if (myName == "mike")
        {
            transform.Translate(mikeVelocity, 0);
            if (transform.position.y > myAltitude + 0.5f || transform.position.y < myAltitude - 1f)
            {
                myVertical = -myVertical;
                mikeVelocity = new Vector2(1f * Time.deltaTime, myVertical * Time.deltaTime);
            }
        }
        else if (myName == "willieCopter")
        {
            transform.Translate(copterVelocity, 0);
            if (transform.position.y > myAltitude + 1f || transform.position.y < myAltitude - 1f)
            {
                myVertical = -myVertical;
                copterVelocity = new Vector2(-1f * Time.deltaTime, myVertical * Time.deltaTime);
            }
        }
        else if (myName == "mutant")
        {
            transform.Translate(-landerVelocity, 0);
        }
        if (myName == "pig" && transform.position.y < -2.5f)
        {
            Die("dead");
        }
            
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && myName == "coin")
            Die("dead");
        else if (other.gameObject.tag == "Player" && myName == "pig")
            Destroy(this.gameObject);
        else if (other.gameObject.tag == "Player" && other.transform.position.y > this.transform.position.y + 0.25f && myName != "willieCopter")
        {
            scr_gameController.SCORE += 100;
            Die("dead");
        }
        else if(other.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }
     }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 13 && other.gameObject.tag == "lightning")
        {
            scr_gameController.SCORE += 100;
            Die("shock");
        }
        else if (other.gameObject.layer == 13)
        {
            scr_gameController.SCORE += 100;
            Die("dead");
        }
    }

    void Die(string deathType)
    {
        Vector2 pigPosition = new Vector2(transform.position.x, transform.position.y - 0.25f);

        GameObject Death;
        if(deathType == "shock")
            Death = Instantiate(myShock, transform.position, transform.rotation);
        else
            Death = Instantiate(myDeath, transform.position, transform.rotation);
        
        GameObject VehicleDeath = Instantiate(myVehicleDeath, transform.position, transform.rotation);
        if(myName == "bob")
            Instantiate(pig, pigPosition, transform.rotation);
        if(myName == "santy")
            Instantiate(sack, pigPosition, transform.rotation);
        Destroy(this.gameObject);
    }
}
