using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float rayLength;

    public float damage;

    private RaycastHit rayHit;

    public LayerMask layerMask;

    public GameObject laserImpactEffect;

    public AudioSource audioSource;

    public AudioClip laserShot;

    [Range(0.0f, 1.0f)] //creates a slider for the audio, must be a float value
    public float laserShotVolume;
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);

        if (Input.GetButtonDown("Fire1")) //GetButtonDown recognizes multiple input commands instead of one. Fire1 is an input preset within the Unity Engine. Edit > project settings > Input shows all input presets
        {
            Shoot();
        }
	}

    void Shoot()
    {
        audioSource.PlayOneShot(laserShot, laserShotVolume);

        if(Physics.Raycast(transform.position, transform.forward, out rayHit, rayLength, layerMask))
        {
            GameObject impactGo = Instantiate(laserImpactEffect, rayHit.point, transform.rotation);

            Destroy(impactGo, 1f);

            print("I hit " + rayHit.transform.name + " !!");

            Enemy enemyRef = rayHit.transform.GetComponent<Enemy>();

            if(enemyRef != null) //!= means does not equal
            {
                enemyRef.TakeDamage(damage);
            }
        }

        else
        {
            print("Miss!");
        }
    }

}
