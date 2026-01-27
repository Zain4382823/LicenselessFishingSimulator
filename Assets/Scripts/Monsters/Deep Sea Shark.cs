using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepSeaShark : MonoBehaviour
{
    // SET UP SEA MONSTER GAME OBJECT - SO THAT WE CAN ACTIVATE IT
    public GameObject SeaMonster;

    // isActive values:  [0] -> Not active  [1] -> Activation triggered  [2] -> Active
    public static int isActive = 0;

    // STRUGGLEPOINTS -> COUNTS HOW MANY TIMES PLAYER MASHES LEFT CLICK DURING QTE!
    int strugglePoints = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ACTIVATION CHECK -> Spawn monster in, set strugglepoints to 0 and start ButtonMashQTE Coroutine!
        if(isActive == 1)
        {
            // activate sea monster object, make the monster visible!
            SeaMonster.SetActive(true);
            // reset strugglePoints back to zero!
            strugglePoints = 0;
            // start ButtonMashQTE coroutine!
            StartCoroutine(ButtonMashQTE());
            // deactivate trigger variable, while also signalling that the Deep Sea Shark is still active..
            isActive = 2;
        }

        // LEFT MOUSE BUTTON CHECK - GRANTS STRUGGLE POINTS IF DEEP SEA SHARK IS ACTIVE
        if(Input.GetMouseButton(0))
        {
            if(isActive == 2)
                strugglePoints += 25;  // player gets 25 struggle points with each left click!
        }
    }

    IEnumerator ButtonMashQTE()
    {
        Debug.Log("DEEP SEA SHARK ATTACKS! Mash Left Mouse Button to survive!"); // ALERT THE PLAYER, TELL THEM TO MASH LEFT CLICK!

        yield return new WaitForSeconds(4f);

        // DOES THE PLAYER HAVE MORE THAN 500 STRUGGLE POINTS??
        
        if (strugglePoints > 500)  // IF THEY DO...
        {
            // PLAYER WINS! REWARD THEM 500 GOLD AND 500 XP!
            Progression.gold += 500;
            Progression.XP += 500;
            // ALSO DEACTIVATE THE DEEP SEA SHARK.
            SeaMonster.SetActive(false);
        }
        else  // BUT IF THE PLAYER DOESN'T HAVE ENOUGH STRUGGLE POINTS...
        {
            // DEEP SEA SHARK WINS! KILL THE PLAYER!
            Player.triggerDeath = true;
            // ALSO DEACTIVATE THE DEEP SEA SHARK.
            SeaMonster.SetActive(false);
        }
    }
}
