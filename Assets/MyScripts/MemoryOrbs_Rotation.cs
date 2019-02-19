using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryOrbs_Rotation : MonoBehaviour {

    public GameObject orb1; //object we will orbit around
    public float speed; //speed of orbiting red cube

    // Use this for initialization
    void Start ()
    {
    
    }
	
	// Update is called once per frame
	void Update ()
    {
        OrbitAround();  
    }

    void OrbitAround()
    {
        transform.RotateAround(orb1.transform.position, Vector3.right, speed * Time.deltaTime);


    }

}
