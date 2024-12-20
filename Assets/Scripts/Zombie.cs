using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public float jumpHeight = 1f;  // Height of the jump
    public float jumpSpeed = 2f;   // Speed of the jump motion
    private float originalYPosition;  // The original Y position of the zombie


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();  // Call the base class Start method
        FleeSpeed = 7f; // Override the speed to 7 for Zombie
        originalYPosition = transform.position.y;  // Store y position
    }

    protected override void FleeFromPlayer()
    {
        base.FleeFromPlayer(); // Retain the basic fleeing behavior

        // Make the zombie jump up and down within a small range
        float newYPosition = originalYPosition + Mathf.Sin(Time.time * jumpSpeed) * jumpHeight;
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}
