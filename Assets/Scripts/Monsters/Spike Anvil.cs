using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class SpikeAnvil : MonoBehaviour
{
    // SET UP ANVIL HITMAN PREFAB - SO WE CAN KEEP SPAWNING THEM IN VIA SCRIPT!!
    public GameObject anvilHitman;

    // isActive values:  [0] -> Not active  [1] -> Activation triggered  [2] -> Active
    public static int isActive = 0;

    // helps keep track of whether spike anvil is flying up, or falling down from above the player.
    int attackStage = 0;

    // normal spike anvil attacks twice, NIGHTMARE SPIKE ANVIL DOUBLE ATTACKS EACH TURN, (BOTH SIDES) SO FOR NIGHTMARE MODE, WE SET IT TO 4 INSTEAD!
    int attacksLeft = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ACTIVATION TRIGGER CHECK
        if(isActive == 1)
        {
            attacksLeft = 3;  // when activated, Spike Anvil gets 3 anvil attacks on the player!
            StartCoroutine(Attack());  // LOAD UP ATTACK COROUTINE!
            isActive = 2;  // SET ISACTIVE VARIABLE TO 2, ["Active"], TO PREVENT ENDLESS LOOPING!
        }
    }

    IEnumerator Attack()
    {
        while (attacksLeft > 0)
        {
            // spawn in Anvil Hitman prefab! (Decrement attacks left with each one spawned)
            Instantiate(anvilHitman, new Vector3(0,10,0) , quaternion.identity);
            attacksLeft--;
            // wait a bit before spawning the next hitman in!
            yield return new WaitForSeconds(1.85f);
        }
    }
}
