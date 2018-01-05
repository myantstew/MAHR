using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_willieExplode : MonoBehaviour 
{
    public GameObject explosion;
    public GameObject ghost;
	void Start () 
    {
        Invoke("Die", 2f);
	}
	
    void Die()
    {
        GameObject myExplosion = Instantiate(explosion, transform.position, transform.rotation)as GameObject;
        GameObject myGhost = Instantiate(ghost, transform.position, transform.rotation)as GameObject;
        Destroy(this.gameObject);
    }
}
