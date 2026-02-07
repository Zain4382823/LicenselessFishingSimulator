using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    // introduce public variable for player animator, allows us to play animations from script!
    public Animator playerAnim;

    // teleport to left fishing spot when player fishes on the left side.
    public static bool TPToLeftFishingSpot = false;
    // teleport to right fishing spot when player fishes on the right side.
    public static bool TPToRightFishingSpot = false;

    // the player will bounce when a fish bites the hook, or when they catch a fish.
    public static bool bounce = false;
    // how high can they bounce? Fishing.cs sets this to 3 for fish bites hook, and 6 for catching fish!
    public static float bounceHeight;

    // if player fails monster QTE, this gets set to true and Death() Coroutine gets triggered!
    public static bool triggerDeath = false;
    // is the player dead? this variable STAYS true for as long as the player is dead, ensuring that they can't move while dead. 
    bool isDead = false;

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

        // (If Fishing Mode is OFF & Player is NOT dead) -> SET RB VELOCITY TO WHATEVER HORIZONTAL / VERTICAL INPUT THE PLAYER IS GIVING US TIMES BY MOVE SPEED.
        if(!Fishing.fishingMode && !isDead)
            rb.velocity = new Vector2 (HorizontalInput * moveSpeed, VerticalInput * moveSpeed);
        else
            rb.velocity = Vector2.zero;  // PLAYER CAN'T MOVE WHILE THEY'RE IN FISHING MODE! (OR IF THEY'RE DEAD) IT'S NOT ALLOWED!!

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
        // CHECK FOR PLAYER DEATH
        if (triggerDeath)
        {
            StartCoroutine(Death());  // start Death coroutine!
            triggerDeath = false;  // deactivate trigger variable!
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))  // colliding with enemy tag = YOU DIE!!
        {
            StartCoroutine(Death());
        }
        else if (other.CompareTag("PlayerDetector"))  // colliding with player detector = anvil detects player below, delete the detector!
        {
            AnvilHitman.playerDetected = true;
            Destroy(other.gameObject);
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

    // DEATH -> Set player sprite to dead sprite, wait 2 seconds and then respawn the player. (set back to idle sprite)
    IEnumerator Death()
    {
        // PLAY DEATH ANIMATION AND SEND DEBUG LOG CONFIRMING DEATH!
        playerAnim.Play("deadPlayer");
        Debug.Log("You are dead. Not big suprise.");
        isDead = true;

        // WAIT 2 SECONDS..
        yield return new WaitForSeconds(1.75f);

        // PLAY IDLE ANIMATION AND RESPAWN PLAYER AT THE TOP OF THE ROOM.
        playerAnim.Play("DownIdle");
        transform.position = new Vector3(0, 4.4f, 0);  // teleport player to the top of the room..
        isDead = false;
    }
}