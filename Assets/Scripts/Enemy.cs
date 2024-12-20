using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float fleeSpeed = 5f; //enemy fleeing speed
    protected float fleeRadius = 12f; //radius at which enemy starts to flee
    private Transform player; //ref. to player's position 
    
    public float FleeSpeed //ENCAPSULTION
    {
        get { return fleeSpeed; }
        protected set { fleeSpeed = Mathf.Max(0f, value); } //speed can't go below 0
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform; //find Gameobject with tag - "Player"
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is within the flee radius, start fleeing
        if (Vector3.Distance(transform.position, player.position) <= fleeRadius)
        {
            FleeFromPlayer();
        }
    }

    protected virtual void FleeFromPlayer() //ABSTRACTION
    {
        // Calculate the direction away from the player
        Vector3 directionAwayFromPlayer = transform.position - player.position;
        directionAwayFromPlayer.y = 0f;  // We only want to move on the x and z plane

        // Normalize the direction to ensure consistent speed and then move the enemy
        transform.Translate(directionAwayFromPlayer.normalized * fleeSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision) //ABSTRACTION
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);  // Destroy the enemy when colliding with the player
        }
    }
}
