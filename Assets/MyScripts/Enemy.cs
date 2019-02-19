using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour

{
    public Material flashMaterial;

    private Material savedMaterial;

    public NavMeshAgent enemyAgent;

    private GameObject target;

    public float health;

    public static int enemyCount = 0;

    private void Start()
    {
        savedMaterial = gameObject.GetComponent<Renderer>().material;

        target = GameObject.FindWithTag("Player");        
    }

    private void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        followPlayer();
    }

    void followPlayer()
    {
        if (target != null)
        {
            enemyAgent.SetDestination(target.transform.position);
        }

    }

    public void TakeDamage(float damageAmount)
    {
        health = health - damageAmount;

        StartCoroutine(Flash());

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator Flash() //function that allows to break out of other functions to initiate this one. Used for "Coroutine" 
    {
        Renderer renderer = GetComponent<Renderer>();
        int flashCount = 3;
        float waitTime = 0.01f;

        for (int i = 0; i < flashCount; i++)
        {
            renderer.material = flashMaterial;

            yield return new WaitForSeconds(waitTime);

            renderer.material = savedMaterial;

            yield return new WaitForSeconds(waitTime);

            renderer.material = flashMaterial;

            yield return new WaitForSeconds(waitTime);

            renderer.material = savedMaterial;

            yield return new WaitForSeconds(waitTime);
        }
    }

}
