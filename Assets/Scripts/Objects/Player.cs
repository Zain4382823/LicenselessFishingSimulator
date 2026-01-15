using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    
    public static bool TPToLeftFishingSpot = false;  // teleport to left fishing spot when player fishes on the left side.
    public static bool TPToRightFishingSpot = false;  // teleport to right fishing spot when player fishes on the right side.

    const float moveSpeed = 0.006f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // WASD MOVEMENT INPUTS -> FISHING MODE MUST BE OFF!!
        if (Input.GetKey(KeyCode.W) && !Fishing.fishingMode)  // MOVE UP
            transform.position = transform.position + new Vector3(0,moveSpeed,0);  // Y INCREMENT
        if (Input.GetKey(KeyCode.A) && !Fishing.fishingMode) // MOVE LEFT
            transform.position = transform.position + new Vector3(-moveSpeed,0,0);  // X DECREMENT
        if (Input.GetKey(KeyCode.S) && !Fishing.fishingMode) // MOVE DOWN
            transform.position = transform.position + new Vector3(0,-moveSpeed,0);  // Y DECREMENT
        if (Input.GetKey(KeyCode.D) && !Fishing.fishingMode)  // MOVE RIGHT
            transform.position = transform.position + new Vector3(moveSpeed,0,0);  // X INCREMENT


        // TELEPORT TO RIGHT FISHING SPOT!
        if (TPToRightFishingSpot)  // when Fishing.cs triggers right fishing spot teleport in Player.cs..
        {
            transform.position = new Vector3(1.24f, 0, 0);  // teleport player to right fishing position..
            TPToRightFishingSpot = false;  // remember to deactivate trigger variable!
        }
        // TELEPORT TO LEFT FISHING SPOT!
        if (TPToLeftFishingSpot)  // when Fishing.cs triggers left fishing spot teleport in Player.cs..
        {
            transform.position = new Vector3(-2.5f, 0, 0);  // teleport player to left fishing position..
            TPToLeftFishingSpot = false;  // remember to deactivate trigger variable!
        }
    }
}