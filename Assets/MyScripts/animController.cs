using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour {

    public Animator anim;
    float timer = 10f;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown("e"))
        {
            anim.Play("Church_Door_B");
            anim.Play("Church_Door_A");
        }        

        if (timer <= 0)
        {
            Application.LoadLevel("Flooded_Grounds");
        }


    }
}
