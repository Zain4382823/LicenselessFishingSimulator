using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepSeaShark : MonoBehaviour
{
    // SET UP OBJECT RENDERER - SO THAT WE CAN HIDE / REVEAL SEA MONSTERS
    private Renderer objRenderer;

    // isActive values:  [0] -> Not active  [1] -> Activation triggered  [2] -> Active
    public static int isActive = 0;

    // STRUGGLEPOINTS -> COUNTS HOW MANY TIMES PLAYER MASHES LEFT CLICK DURING QTE!
    int strugglePoints = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component attached to this GameObject
        objRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // ACTIVATION CHECK -> Spawn monster in, set strugglepoints to 0 and start ButtonMashQTE Coroutine!
        if(isActive == 1)
        {
            // set objRenderer.enabled to true, which makes the monster visible!
            objRenderer.enabled = true;
            // reset strugglePoints back to zero!
            strugglePoints = 0;
            // start ButtonMashQTE coroutine!
            StartCoroutine(ButtonMashQTE());
            // deactivate trigger variable, while also signalling that the Deep Sea Shark is still active..
            isActive = 2;
        }

        // LEFT MOUSE BUTTON CHECK - GRANTS STRUGGLE POINTS IF DEEP SEA SHARK IS ACTIVE
        if(Input.GetMouseButtonDown(0))
        {
            if(isActive == 2)
                strugglePoints += 25;  // player gets 25 struggle points with each left click!
        }
    }

    IEnumerator ButtonMashQTE()
    {
        Debug.Log("DEEP SEA SHARK ATTACKS! Mash Left Mouse Button to survive!"); // ALERT THE PLAYER, TELL THEM TO MASH LEFT CLICK!

        yield return new WaitForSeconds(4f);

        // DOES THE PLAYER HAVE MORE THAN 400 STRUGGLE POINTS??
        
        if (strugglePoints > 400)  // IF THEY DO...
        {
            // PLAYER WINS! REWARD THEM 500 GOLD AND 500 XP!
            Progression.gold += strugglePoints;
            Progression.XP += strugglePoints;
            
            // ALSO HIDE THE DEEP SEA SHARK BY DISABLING OBJECT RENDERER!
            objRenderer.enabled = false;

            // SEND DEBUG LOG SIGNALLING THAT THE PLAYER WON!
            Debug.LogFormat("YOU SURVIVED!! You won {0} Gold and {0} XP!", strugglePoints);
        }
        else  // BUT IF THE PLAYER DOESN'T HAVE ENOUGH STRUGGLE POINTS...
        {
            // DEEP SEA SHARK WINS! KILL THE PLAYER!
            Player.triggerDeath = true;

            // ALSO HIDE THE DEEP SEA SHARK BY DISABLING OBJECT RENDERER!
            objRenderer.enabled = false;
            
            // SEND DEBUG LOG SIGNALLING THAT THE PLAYER LOST!
            Debug.Log("OUCH! You died to the Deep Sea Shark..");
        }
    }
}
