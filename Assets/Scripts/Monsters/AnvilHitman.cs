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
    float moveSpeed = 5f;

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

        // SPAWN ANVIL HITMAN IN BOTTOM LEFT / RIGHT POSITION BASED ON DIRECTION VALUE!!
        if (Direction == "Right")
            rb.position = new Vector3(10.79f, -5.524f, 0f);  // BOTTOM RIGHT POSITION : (10.79, -5.524, 0)
        else
            rb.position = new Vector3(-10.419f, -5.524f, 0f);  // BOTTOM LEFT POSITION : (-10.419, -5.524, 0)

        // MAKE ANVIL HITMAN MOVE DIAGONALLY! SETTING RB VELOCITY BASED ON DIRECTION!!
        if(Direction == "Right")
            rb.velocity = new Vector2(-1,1) * moveSpeed;  // Right Direction -> FLY UP-LEFT!!
        else
            rb.velocity = new Vector2(1, 1) * moveSpeed; // Left Direction -> FLY UP-RIGHT!!
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
