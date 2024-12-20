using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBlob : Enemy //INHERITANCE
{
    public float spinSpeed = 15f;

    protected override void FleeFromPlayer() //POLYMORPHISM
    {
        base.FleeFromPlayer(); // INHERITANCE and Retain the fleeing behavior from "Enemy.cs" 

        // Spin the AlienBlob continuously on its y-axis
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
    }
}
