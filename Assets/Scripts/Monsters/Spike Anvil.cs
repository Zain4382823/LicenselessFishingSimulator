using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAnvil : MonoBehaviour
{
    // SET UP OBJECT RENDERER - SO THAT WE CAN HIDE / REVEAL SEA MONSTERS
    private Renderer objRenderer;

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
            StartCoroutine(Attack());  // LOAD UP ATTACK COROUTINE!
            isActive = 2;  // SET ISACTIVE VARIABLE TO 2, ["Active"], TO PREVENT ENDLESS LOOPING!
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2f);
    }
}
