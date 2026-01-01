using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // introduce public variable for player animator, allows us to play animations from script!
    public Animator playerAnim;
    
    int fishCount = 0;  // when player catches fish, we increment fish count by 1!

    bool fishingMode = false;  // FISHING MODE: player casts line, waits for fish, fish bites hook, then player catches the fish!
    bool fishingModeCooldown = false;  // prevents spamming F key, which confuses the program..

    string caughtFish = "N/A";  // catching fish status, triggered when fish bites the hook. used for FishBitesTheHook() enum.

    // caughtFish values and what they mean:

    // ("N/A") -> Fish does not exist / player already caught fish, so it reset.
    // ("NotCaught") -> Fish has bitten the hook, but player has not caught it yet! if player doesn't catch it in time, the fish gets away!

    // Start is called before the first frame update
    void Start()
    {
        // let's just say the player's idle for now...
        Debug.Log("Currently idle..");
        Debug.Log("(Press F to enter fishing mode!)");
    }

    // Update is called once per frame
    void Update()
    {
        // Handle F key inputs -> Enter / Exit Fishing Mode!
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!fishingMode && !fishingModeCooldown)  // if fishing mode is off, and no cooldown..
            {
                // turn fishing mode ON!!
                fishingMode = true;
                Debug.Log("Casting the line..");
                // automatically start up WaitingForFish() coroutine..
                StartCoroutine(WaitingForFish());
                // activate cooldown to prevent spamming + start timer to deactivate cooldown after a few seconds..
                fishingModeCooldown = true;
                StartCoroutine(FishModeCDTimer());
            }
            else if (fishingMode && !fishingModeCooldown)  // if fishing mode is on, and no cooldown..
            {
                // turn fishing mode OFF!!
                fishingMode = false;
                playerAnim.Play("playerIdle");
                Debug.Log("You suddenly decided to stop fishing!");
                // Stop ALL FISHING COROUTINES!!
                StopCoroutine(WaitingForFish());
                StopCoroutine(FishBitTheHook());
                // activate cooldown to prevent spamming + start timer to deactivate cooldown after a few seconds..
                fishingModeCooldown = true;
                StartCoroutine(FishModeCDTimer());
            }
        }

        // Handle C key inputs -> Catch a fish!
        if (Input.GetKeyDown(KeyCode.C) && fishingMode && caughtFish == "NotCaught")  // if fishing mode is ON, a fish has bitten the hook, and player presses C..
        {
            // FISH TYPE RNG CHECK - SPIN THE WHEEL!! WHAT'S THE DROP GONNA BE?
            if (Random.value < 0.5)  // 50/50 chance for either Fish / Junk catch! 
                Fish.fishID = "Fish";
            else
                Fish.fishID = "Junk";

            // player successfully caught the fish, increment fish count by 1!
            fishCount++;
            playerAnim.Play("playerCaughtFish");

            // send confirmation log, message varies based on Fish ID
            if (Fish.fishID == "Fish")
                Debug.Log("Congrats! You caught the fish!");
            else
                Debug.Log("EWWW!! You caught JUNK!!");

            // turn fishing mode OFF and reset caughtFish to "N/A".
            fishingMode = false;
            caughtFish = "N/A";
        }
    }

    // COOLDOWN TIMER -> player is not allowed to spam F key, must wait a bit before toggling fishing mode ON / OFF!
    IEnumerator FishModeCDTimer()
    {
        yield return new WaitForSeconds(2);
        fishingModeCooldown = false;
    }

    // WAITING FOR FISH -> wait 3 seconds for a fish to bite!
    IEnumerator WaitingForFish()
    {
        // PLAY SWING BACK ANIMATION -> (IN ANIMATOR..) TRANSITIONS TO FISHING IDLE AFTER 0.5 SECONDS!!
        playerAnim.Play("playerSwingBack");
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Line casted! And now, we wait for fish..");
        
        yield return new WaitForSeconds(3);

        // FISHING SPEED RNG!
        bool waitingForFish = true;

        while(waitingForFish)  // every 3 second interval, run a x% chance to advance to "FishBitTheHook()" stage!
        {
            if (Random.value < 0.5)  // 50% chance.
                waitingForFish = false;  // on a successful roll, exit the while loop and advance to the next stage!
            else
                Debug.Log("Fishing dice roll failed!!");
                yield return new WaitForSeconds(3);  // if we fail this roll, we wait another 3 seconds before trying again..
        }

        // advance to "FishBitTheHook()" stage!
        if (fishingMode)
            StartCoroutine(FishBitTheHook());
    }

    // FISH BIT THE HOOK -> quick time event! player has a 1.5 second time window, to press C in order to catch the fish!
    IEnumerator FishBitTheHook()
    {
        if (fishingMode)
        {
            caughtFish = "NotCaught";  // signals to the program that a fish bit the hook, but has not been caught.
            playerAnim.Play("FishBitesHook");
            Debug.Log("A fish has bitten the hook!! Press C to catch the fish!");

            yield return new WaitForSeconds(1f);  // wait 1.5 seconds for player to catch fish..

            if (caughtFish == "NotCaught" && fishingMode)  // if time runs out, and player still hasn't caught the fish..
            {
                // turn fishing mode OFF and reset caughtFish to "N/A".
                fishingMode = false;
                caughtFish = "N/A";
                // the fish gets bored and escapes! womp womp..
                playerAnim.Play("playerIdle");
                Debug.Log("Oh no! The fish got away!");
            }
        }
    }
}