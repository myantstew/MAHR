using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_deathScript : MonoBehaviour 
{
    Animator anim;
    Vector2 upMotion;
    public Rigidbody2D myBody;
    float myVelocity;
    bool goingUp = true;
    public string myName;
    public GameObject egg;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        upMotion = new Vector2(0, 100f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (goingUp)
            ImGoingUp();
        myVelocity = myBody.velocity.y;
        anim.SetFloat("velocity", myVelocity);

        if (this.transform.position.y < -4)
        {
            if (myName == "maurice" && !GameObject.FindWithTag("Player") && scr_gameController.LIVES > 0)
                NewEgg();
            else if (myName == "maurice" && !GameObject.FindWithTag("Player") && scr_gameController.LIVES <= 0)
                scr_gameController.GAMEOVER();
            else
                Destroy(this.gameObject);
        }
	}

    void ImGoingUp()
    {
        myBody.AddForce(upMotion);
        goingUp = false;
    }
    void NewEgg()
    {
        Vector3 eggPosition = new Vector3(-3.75f, -3f, 0);
        GameObject NewEgg = Instantiate(egg, eggPosition, Quaternion.identity) as GameObject;
        Destroy(this.gameObject);
    }
}
