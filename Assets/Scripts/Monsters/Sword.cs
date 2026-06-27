using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Rigidbody2D rb;
    bool startSpinning = false;

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
        rb.velocity = new Vector2(-10f,0f);  // LAUNCH SWORD LEFTWARDS!!
    }
}
