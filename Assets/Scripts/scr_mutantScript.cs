using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_mutantScript : MonoBehaviour 
{
    public Vector2 myVelocity;
    public Vector2 dropVelocity;
    public Vector2 crossVelocity;

    public GameObject myDeath;
    public GameObject myVehicleDeath;
    public GameObject player;

    public string myName;

    private float RotateSpeed = 6f;
    private float Radius = .5f;
    private Vector2 _center;
    private float _angle;

    public bool dropIn;
    public bool hover;
    public bool crossLeft;
    public bool crossRight;

    public bool startCross;

	// Use this for initialization
	void Start () 
    {
        _center = new Vector3(transform.position.x, transform.position.y-0.5f, 0);
        myVelocity = new Vector2(1f*Time.deltaTime, 1f*Time.deltaTime);
        dropVelocity = new Vector2(0f*Time.deltaTime, -1f*Time.deltaTime);
        crossVelocity = new Vector2(3f*Time.deltaTime, 0f*Time.deltaTime);
        dropIn = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 myScale = new Vector3(1,1,1);;
        Vector3 reverse = new Vector3(-1,1,1);
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);

        if (dropIn)
        {
            transform.Translate(dropVelocity, 0);
            if (this.transform.position.y < 0.5f)
            {
                dropIn = false;
                _center = transform.position;
                hover = true;
                if (startCross = true)
                {
                    StartCoroutine("CrossTimer");
                    startCross = false;
                }
            }
        }

        else if (hover)
        {
           _angle += RotateSpeed * Time.deltaTime;
           var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
          transform.position = _center + offset;
            if (startCross = true)
            {
                Crossing();
            }
        }
        else if(crossLeft)
        {
            startCross = false;
            crossRight = false;
            transform.Translate(-crossVelocity, 0);
            if(transform.position.x< -2f)
            {
                _center = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
                _angle = 0;
                hover = true;
                crossLeft = false;
                startCross = true;
            }
        }
        else if(crossRight)
        {
            startCross = false;
            crossLeft = false;
            transform.Translate(crossVelocity, 0);
            if(transform.position.x> 2f)
            {
                _center = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
                _angle = 0;
                hover = true;
                crossRight = false;
                startCross = true;
            }
        }

        //pig facing player
        if (player && this.transform.position.x < playerPos.x)
            this.transform.localScale = reverse;
        else
            this.transform.localScale = myScale;
	}

    void Crossing()
    {
        if (startCross)
        {
            startCross = false;
            StartCoroutine("CrossTimer");
        }
    }

    IEnumerator CrossTimer()
    {
        startCross = false;
        yield return new WaitForSeconds(6);
        hover = false;
        if (transform.position.x > 1 && crossRight == false)
        {
            crossLeft = true;
            crossRight = false;
        }
        else if (transform.position.x < -1 && crossLeft == false)
        {
            crossRight = true;
            crossLeft = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.transform.position.y > this.transform.position.y + 0.25f)
            Die();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 13)
            Die();
    }

    void Die()
    {
         GameObject Death = Instantiate(myDeath, transform.position, transform.rotation);
        GameObject VehicleDeath = Instantiate(myVehicleDeath, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
