﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //now gives you access to the function of level load

public class Interact : MonoBehaviour {

    public float rayLength;

    private RaycastHit objectHit;

    public Material highlightMaterial;

    private GameObject curObj;

    public LayerMask layerMask;

    private Material savedMaterial;

    public int keysNeeded;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.blue); //sets the raycast
       
        // If we hit something...
        if (Physics.Raycast(transform.position, transform.forward, out objectHit, rayLength, layerMask))
        {
           // print("I hit " + objectHit.transform.name); //this is one way to print the objectHit name. Could also use objectHit.collider.name

            if (Input.GetKeyDown(KeyCode.E))
            {
                ObjInteraction(curObj);
            }
            

            if (curObj == null) // == is a check. IF we hit something, and curObj is not assigned a gameobject, then...
            {
                // Assign curObj the gameObject I'm hitting
                curObj = objectHit.collider.gameObject;

                savedMaterial = curObj.GetComponent<Renderer>().material;

                curObj.GetComponent<Renderer>().material = highlightMaterial; //assigns curObj to material (the white material highlight)
            }

            if (curObj != null && curObj != objectHit.transform.gameObject) // != not equal to. This is staying if the game object your currently looking at is not the same as the original object, then nullify it.
            {
                NullifyCurObj();
            }
        }

        else
        {
            //ELSE, if my ray is NOT hitting something BUT curOBJ is still assigned...
            if (curObj != null)
            {
                NullifyCurObj();
            }
        }    
    }

    void NullifyCurObj()
    {
            curObj.GetComponent<Renderer>().material = savedMaterial;

            curObj = null;
    }

    void ObjInteraction(GameObject objFromRaycast)
    {
        /*if (objFromRaycast.tag == "Key")
        {
            PlayerInventory.keyCount++;

            print("I have " + PlayerInventory.keyCount + " keys!");

            Destroy(objFromRaycast);

        } */

       /* if (objFromRaycast.tag == "Door")
        {
           // if (PlayerInventory.keyCount >= keysNeeded)
           // {
            //    PlayerInventory.keyCount = 0;
            SceneManager.LoadScene("Flooded_Grounds");
        }

        /* else
         {
              print("I still need " + (keysNeeded - PlayerInventory.keyCount) + " keys!");
         }
      } */
    }

}
