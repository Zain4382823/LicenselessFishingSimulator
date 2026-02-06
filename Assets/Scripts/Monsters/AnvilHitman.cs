using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilHitman : MonoBehaviour
{
    // setup RigidBody2D!
    Rigidbody2D rb;
    
    // set up SpriteRenderer!
    SpriteRenderer spriteRenderer;
    
    // set up angry sprite!
    public Sprite angry;

    // ITS SPEED!! multiply this by the direction the Anvil Hitman's going in!
    float moveSpeed = 15f;

    // ALL ATTACK STAGES -> {1 - Rising up} {2 - Searching for player} {3 - Falling onto player}
    int attackStage = 1;

    // which direction will Anvil Hitman spawn from?? (And which direction will they move AFTER spawning??)
    string Direction = "Right";

    // when player is directly below the Anvil Hitman, this variable is set to true!
    bool playerDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        // setup rb component!
        rb = GetComponent<Rigidbody2D>();
        // setup sprite renderer component!
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 50% chance to switch to Left direction instead!
        if (Random.value < 0.5)
            Direction = "Left";

        // SPAWN TELEPORT & SET VELOCITY BASED ON DIRECTION!!
        switch (Direction)
        {
            case "Right":
                rb.position = new Vector3(10.79f, -5.524f, 0f);  // BOTTOM RIGHT SPAWN POSITION : (10.79, -5.524, 0)
                rb.velocity = new Vector2(-1, 1) * moveSpeed;  // Bottom Right Spawn -> FLY UP-LEFT!!
                break;
            case "Left":
                rb.position = new Vector3(-11.75f, -5.5f, 0f);  // BOTTOM LEFT SPAWN POSITION : (-11.75, -5.5, 0)
                rb.velocity = new Vector2(1, 1) * moveSpeed;  // Bottom Left Spawn -> FLY UP-RIGHT!!
                break;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        // IF SPIKE ANVIL REACHES MAX HEIGHT, MAKE IT STOP!!
        if (rb.position.y >= 3.75 && attackStage == 1)   // MAX Y LIMIT : (3.75)
        {
            // STOP!!!
            rb.velocity = Vector2.zero;
            attackStage = 2;

            StartCoroutine(SearchForPlayer());
        }
    }

    IEnumerator SearchForPlayer()
    {
        // Wait a bit, this will give us time to check if player's already under Anvil Hitman..
        yield return new WaitForSeconds(0.025f);

        // ONLY SEARCH FOR THE PLAYER IF THEY AREN'T ALREADY UNDERNEATH ANVIL HITMAN!
        if (Direction == "Right" && attackStage == 2)
        {
            rb.velocity = Vector2.left * moveSpeed;  // Coming from the right, Anvil Hitman searches LEFTWARDS!!!
        }
        else if (Direction == "Left" && attackStage == 2)
        {
            rb.velocity = Vector2.right * moveSpeed;  // Coming from the left, Anvil Hitman searches RIGHTWARDS!!!
        }
    }
}
