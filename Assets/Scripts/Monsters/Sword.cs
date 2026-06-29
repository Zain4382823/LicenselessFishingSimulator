using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // declaring rigidbody
    Rigidbody2D rb;

    // START SPINNING -> setting this variable to true causes the sword to start spinning. this triggers when the sword gets launched at player!
    bool startSpinning = false;

    // CAN PARRY -> bool variable that becomes true after parry timer runs out. player must then press P to parry the sword!
    bool CanParry = false;

    // introduce velocity variables!
    float xVelocity;
    float yVelocity;

    // SPAWN POS -> RNG string variable, determines where the sword spawns and the directions we launch it towards!
    string SpawnPos = "Top Middle";

    /* ALL POSSIBLE SPAWN POSITIONS:
    
    .TOP LEFT -> (-1.5f, 2.51f, 0f)
    .TOP MIDDLE -> (1.24f, 4.07f, 0f)
    .TOP RIGHT -> (4.3f, 2.55f, 0f)

    .MIDDLE LEFT -> (-3.5f, 0.11f, 0f)
    .MIDDLE RIGHT -> (3.76f, 0.11f, 0f)

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

        // using RNG, determine which spawn position we'll be using!
        if (UnityEngine.Random.value < 0.2)
            SpawnPos = "Top Left";
        if (UnityEngine.Random.value < 0.2)
            SpawnPos = "Top Middle";
        if (UnityEngine.Random.value < 0.2)
            SpawnPos = "Top Right";

        if (UnityEngine.Random.value < 0.15)
            SpawnPos = "Middle Left";
        if (UnityEngine.Random.value < 0.15)
            SpawnPos = "Middle Right";

        if (UnityEngine.Random.value < 0.10)
            SpawnPos = "Bottom Left";
        if (UnityEngine.Random.value < 0.10)
            SpawnPos = "Bottom Middle";
        if (UnityEngine.Random.value < 0.10)
            SpawnPos = "Bottom Right";

        // now we use a switch statement to set position and velocity based on SpawnPos value!
        switch(SpawnPos)
        {
            case "Top Left":
                transform.position = new Vector3(-1.5f, 2.51f, 0f);
                xVelocity = 5f;
                yVelocity = -5f;
                break;
            case "Top Middle":
                transform.position = new Vector3(1.24f, 4.07f, 0f);
                xVelocity = 0f;
                yVelocity = -5f;
                break;
            case "Top Right":
                transform.position = new Vector3(4.2f, 2.85f, 0f);
                xVelocity = -5f;
                yVelocity = -5f;
                break;

            case "Middle Left":
                transform.position = new Vector3(-3f, 0.11f, 0f);
                xVelocity = 5f;
                yVelocity = 0f;
                break;
            case "Middle Right":
                transform.position = new Vector3(4.76f, 0.11f, 0f);
                xVelocity = -5f;
                yVelocity = 0f;
                break;

            case "Bottom Left":
                transform.position = new Vector3(-1.5f, -2.51f, 0f);
                xVelocity = 5f;
                yVelocity = 5f;
                break;
            case "Bottom Middle":
                transform.position = new Vector3(1.24f, -4.07f, 0f);
                xVelocity = 0f;
                yVelocity = 5f;
                break;
            case "Bottom Right":
                transform.position = new Vector3(4.39f, -2.51f, 0f);
                xVelocity = -5f;
                yVelocity = 5f;
                break;
        }

        // start up attack delay coroutine -> wait 1 second before launching sword at player!
        StartCoroutine(AttackDelay());
    }

    // Update is called once per frame
    void Update()
    {
        // make the sword constantly spin around!
        if(startSpinning)
            transform.Rotate(0f, 0f, -0.75f, Space.Self);

        // PARRY! -> press P in time and the sword deletes itself!
        if (Input.GetKeyDown(KeyCode.P) && CanParry)
            Destroy(gameObject);
    }

    IEnumerator AttackDelay()
    {
        // wait 1 second
        yield return new WaitForSeconds(0.5f);
        // sword starts spinning now!!
        startSpinning = true;
        // launch sword towards the player! (i'll use a velocity for this why not..)
        rb.velocity = new Vector2(xVelocity, yVelocity);  // LAUNCH SWORD LEFTWARDS!!

        // start up ParryTimer coroutine -> wait a short amount of time before allowing the player to parry!
        StartCoroutine(ParryTimer());
    }

    IEnumerator ParryTimer()
    {
        // wait a short amount of time..
        yield return new WaitForSeconds(0.4f);
        // you can now parry! set CanParry to true!
        CanParry = true;
    }
}
