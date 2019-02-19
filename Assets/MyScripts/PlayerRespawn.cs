using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

    private Vector3 respawnPosition; //Vector3 is a point in space x,y,z
    //collider stores collision information

	// Use this for initialization
	void Start ()
    {
        respawnPosition = transform.position;	       
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            //respawnPosition = transform.position;
            respawnPosition = other.transform.position; 
        }

        if(other.gameObject.tag == "Killbox")
        {
            transform.position = respawnPosition;
        }       
    }

}
