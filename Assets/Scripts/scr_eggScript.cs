using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_eggScript : MonoBehaviour 
{
    Rigidbody2D myRigidbody;
    public GameObject explosion;
    public GameObject player;
    bool amIDead;

	// Use this for initialization
	void Start () 
    {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector2 motion = new Vector2(1.5f, 1.5f);
        myRigidbody.velocity = motion;
        if (myRigidbody.position.y > 1 && amIDead == false)
            Die();
	}

    void Die()
    {
        amIDead = true;
        GameObject myExplosion = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        GameObject myPlayer = Instantiate(player, transform.position, Quaternion.identity) as GameObject;
        Destroy(this.gameObject);
    }

}
