using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // start up attack delay coroutine -> wait 1.25 seconds before launching sword at player!
        StartCoroutine(AttackDelay());
    }

    // Update is called once per frame
    void Update()
    {
        // make the sword constantly spin around!
        transform.Rotate(0f, 0f, -0.5f, Space.Self);
    }

    IEnumerator AttackDelay()
    {
        // wait 1.25 seconds
        yield return new WaitForSeconds(1.25f);
        // launch sword towards the player! (i'll use a velocity for this why not..)
    }
}
