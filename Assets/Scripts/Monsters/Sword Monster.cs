using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SwordMonster : MonoBehaviour
{
    // SET UP SWORD PREFAB - SO WE CAN KEEP SPAWNING SWORDS IN VIA SCRIPT!!
    public GameObject Sword;

    // ATTACK STATE - basically this is an attack trigger variable!
    public static int attackState = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check attack state, load Attack() if it's 1!
        if (attackState == 1)
        {
            StartCoroutine(Attack());
            attackState = 2;  // doing this to prevent endless loops!
        }
    }

    IEnumerator Attack()
    {
        Debug.Log("SWORD MONSTER ATTACKS! When a sword gets close enough, press P to parry it!"); // ALERT THE PLAYER, TELL THEM TO PARRY USING P!

        // first off, start up the attack timer!
        StartCoroutine(AttackTimer());

        // do a while loop!
        while (attackState > 0)
        {
            // spawn swords every 1 seconds!
            Instantiate(Sword, new Vector3(0, 0, 0), quaternion.identity);
            yield return new WaitForSeconds(0.275f);
        }
    }

    IEnumerator AttackTimer()
    {
        // wait for 5 seconds and then deactivate attack by setting attack state to 0!!
        yield return new WaitForSeconds(5);
        attackState = 0;
    }
}
