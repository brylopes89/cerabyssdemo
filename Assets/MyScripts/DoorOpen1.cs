using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen1 : MonoBehaviour {

    private Animator _animator;

	// Use this for initialization
	void Start ()
    {

        _animator = GetComponent<Animator>();
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("open", true);
        }
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
