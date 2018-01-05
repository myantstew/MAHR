using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_powerUp : MonoBehaviour 
{
    Rigidbody2D myBody;
    Vector2 myThrow;
    Vector2 mothSpeed;
    Vector2 throwPower;
    public string myName;

    public GameObject coinExplode;
    public GameObject coinValue;

    // Use this for initialization
    void Start () 
    {
        myBody = GetComponent<Rigidbody2D>();

        mothSpeed = new Vector2(0.5f, 0);
        if (myName == "cheese" || myName == "quarter" || myName == "dime")
            throwPower = new Vector2(0,100);
        else if(myName == "moth")
            throwPower = new Vector2(0,0);
        else if(myName == "bulb")
            throwPower = new Vector2(0,10);
        else if(myName == "rock")
            throwPower = new Vector2(100,250);
        myThrow = throwPower;
            myBody.AddForce(myThrow);
    }
    void Update()
    {
        if (myName == "moth")
            myBody.velocity = mothSpeed;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
            if (this.gameObject.tag == "dime" || this.gameObject.tag == "quarter")
            {
                GameObject myExplosion = Instantiate(coinExplode, transform.position, transform.rotation)as GameObject;
                GameObject myValue = Instantiate(coinValue, transform.position, transform.rotation)as GameObject;
                Destroy(this.gameObject);
            }
            else
                Destroy(this.gameObject);
    }
}
