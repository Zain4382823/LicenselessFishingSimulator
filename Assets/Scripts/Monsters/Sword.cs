using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // declaring rigidbody
    Rigidbody2D rb;

    // START SPINNING -> setting this variable to true causes the sword to start spinning. this triggers when the sword gets launched at player!
    bool startSpinning = false;

    // introduce velocity variables!
    float xVelocity;
    float yVelocity;

    // SPAWN POS -> RNG string variable, determines where the sword spawns and the directions we launch it towards!
    string SpawnPos = "Top Middle";

    /* ALL POSSIBLE SPAWN POSITIONS:
    
    .TOP LEFT -> (-1.5f, 2.51f, 0f)
    .TOP MIDDLE -> (1.24f, 4.07f, 0f)
    .TOP RIGHT -> (4.39f, 2.51f, 0f)

    .MIDDLE LEFT -> (-6.76f, 0.11f, 0f)
    .MIDDLE RIGHT -> (6.76f, 0.11f, 0f)

    .BOTTOM LEFT -> (-1.5f, -2.51f, 0f)
    .BOTTOM MIDDLE -> (1.24f, -4.07f, 0f)
    .BOTTOM RIGHT -> (4.39f, -2.51f, 0f)  */


    // Start is called before the first frame update
    void Start()
    {
        // set up rb component in Start()
        rb = GetComponent<Rigidbody2D>();

        // initialise rb velocity as zero
        rb.velocity = Vector2.zero;

        // start up attack delay coroutine -> wait 1 second before launching sword at player!
        StartCoroutine(AttackDelay());
    }

    // Update is called once per frame
    void Update()
    {
        // make the sword constantly spin around!
        if(startSpinning)
            transform.Rotate(0f, 0f, -0.75f, Space.Self);
    }

    IEnumerator AttackDelay()
    {
        // wait 1 second
        yield return new WaitForSeconds(0.5f);
        // sword starts spinning now!!
        startSpinning = true;
        // launch sword towards the player! (i'll use a velocity for this why not..)
        rb.velocity = new Vector2(xVelocity, yVelocity);  // LAUNCH SWORD LEFTWARDS!!
    }
}
