using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("I'm triggered!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
      if(other.gameObject.tag == "Player")
        {
            print("I'm still triggered!!!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("I'm no longer triggered");
        }
    }

}
