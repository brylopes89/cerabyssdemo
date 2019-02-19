using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttachment : MonoBehaviour
{

    public GameObject thePlatform;

    private GameObject player;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

    }

    private void OnTriggerEnter(Collider go)
    {
        if(go.gameObject.tag == "Player")
        {
            player.transform.parent = thePlatform.transform; //.parent accesses the parent that is directly above the object... .root would access the master parent
        }
       
    }

    private void OnTriggerExit(Collider go)
    {
        if(go.gameObject.tag == "Player")
        {
            player.transform.parent = null;
        }
        
        
    }

}


	

