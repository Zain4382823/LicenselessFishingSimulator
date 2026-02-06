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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
