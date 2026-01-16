using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    // introduce public variable for player animator, allows us to play animations from script!
    public Animator playerAnim;

    public static bool TPToLeftFishingSpot = false;  // teleport to left fishing spot when player fishes on the left side.
    public static bool TPToRightFishingSpot = false;  // teleport to right fishing spot when player fishes on the right side.
    public static bool bounce = false; // the player will bounce when a fish bites the hook, or when they catch a fish.

    public static float bounceHeight; // how high can they bounce? Fishing.cs sets this to 3 for fish bites hook, and 6 for catching fish!

    float HorizontalInput;
    float VerticalInput;

    const float moveSpeed = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // HANDLING PLAYER MOVEMENT VIA RIGIDBODY
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        // (If Fishing Mode is OFF) -> SET RB VELOCITY TO WHATEVER HORIZONTAL / VERTICAL INPUT THE PLAYER IS GIVING US TIMES BY MOVE SPEED.
        if(!Fishing.fishingMode)
            rb.velocity = new Vector2 (HorizontalInput * moveSpeed, VerticalInput * moveSpeed);
        else
            rb.velocity = Vector2.zero;  // PLAYER CAN'T MOVE WHILE THEY'RE IN FISHING MODE! IT'S NOT ALLOWED!!

        // UPDATE xVelocity AND yVelocity PARAMETERS IN PLAYER ANIMATOR
        playerAnim.SetFloat("xVelocity", rb.velocity.x);
        playerAnim.SetFloat("yVelocity", rb.velocity.y);


        // CHECK IF BOUNCE ANIMATION HAS BEEN TRIGGERED!
        if (bounce)
        {
            StartCoroutine(Bounce(bounceHeight));  // play Bounce anim, using the bounce height Fishing.cs gave us..
            bounce = false; // don't forget to deactivate the trigger variable!
        }
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

    // BOUNCE -> Bounce animation plays when a fish bites the hook, (3 bounce height) OR the player catches a fish! (7 bounce height)
    IEnumerator Bounce(float bounceHeight)
    {
        // MOVE THE PLAYER UP!
        for(int i = 1; i <= bounceHeight; i++)
        {
            transform.position = transform.position + new Vector3(0, 0.12f, 0);
            yield return new WaitForSeconds(0.025f);
        }
        // MOVE THE PLAYER BACK DOWN!
        for (int i = 1; i <= bounceHeight; i++)
        {
            transform.position = transform.position + new Vector3(0, -0.12f, 0);
            yield return new WaitForSeconds(0.025f);
        }
    }
}