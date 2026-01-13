using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    // introduce public variable for player animator, allows us to play animations from script!
    public Animator playerAnim;

    int fishCount = 0;  // when player catches fish, we increment fish count by 1!

    public static bool fishingMode = false;  // FISHING MODE: player casts line, waits for fish, fish bites hook, then player catches the fish!
    bool fishingModeCooldown = false;  // prevents spamming F key, which confuses the program..

    string caughtFish = "N/A";  // catching fish status, triggered when fish bites the hook. used for FishBitesTheHook() enum.

    // caughtFish values and what they mean:

    // ("N/A") -> Fish does not exist / player already caught fish, so it reset.
    // ("NotCaught") -> Fish has bitten the hook, but player has not caught it yet! if player doesn't catch it in time, the fish gets away!

    bool fishingLeft = false; // is the player fishing on the left side?..

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
                
                // SET PLAYER ANIM TO IDLE        
                if(!fishingLeft)
                    playerAnim.Play("playerIdle");  // FISHING RIGHT -> stick to default idle anim!
                else
                    playerAnim.Play("LeftIdle");  // FISHING LEFT -> use left version instead!
                
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
            FishingLootTableRNG();  // first, we use a separate function to determine what the player's fishing loot will be..

            // player successfully caught the fish, increment fish count by 1!
            fishCount++;

            // PLAY CAUGHT FISH ANIMATION!
            if (!fishingLeft)
                playerAnim.Play("playerCaughtFish");  // FISHING RIGHT -> stick to default animation!
            else
                playerAnim.Play("LeftCaughtFish");  // FISHING LEFT -> use left version instead!

            // award base gold & XP as a reward.
            Progression.gold += 50;
            Progression.XP += 25;

            // send confirmation log, message varies based on Fish ID
            Debug.LogFormat("{0}! You caught: {1}!", Fish.fishType.ToUpper(), Fish.fishID);

            // turn fishing mode OFF and reset caughtFish to "N/A".
            fishingMode = false;
            caughtFish = "N/A";
        }
    }

    // FISHINGLOOTTABLERNG() -> SPIN THE RNG WHEEL!! WHAT'S THE DROP GONNA BE?
    void FishingLootTableRNG()
    {
        // PHASE 1 - RNG Determines Fish Type..

        if (UnityEngine.Random.value < 0.65)  // 65% chance for Fish!
            Fish.fishType = "Fish";
        else if (UnityEngine.Random.value < 0.25)  // 25% chance for Sea Monster!
            Fish.fishType = "Sea Monster";
        else if (UnityEngine.Random.value < 0.20)  // 20% chance for Treasure!
            Fish.fishType = "Treasure";
        else if (UnityEngine.Random.value < (1 / 1000000000))  // One in a BILLION chance for Nightmare Orb, RAREST DROP IN THE GAME!!
            Fish.fishType = "Nightmare Orb";
        else
            Fish.fishType = "Junk";  // otherwise, if it ain't fish, treasure, sea monster, or a nightmare orb.. it's junk!


        // PHASE 2 - Based on chosen Fish Type, RNG determines which item we get from that specific loot table..

        switch (Fish.fishType)
        {
            case "Fish":  // FISH LOOT TABLE:

                Fish.fishID = "Saltwater Trout";  // by default, start by assuming we caught Saltwater Trout. (50 gold + 25 XP)

                // RNG determines whether or not we get a different kinda fish..
                if (UnityEngine.Random.value < 0.5)
                    Fish.fishID = "Silver Salmon";  // 100 gold + 50 XP
                else if (UnityEngine.Random.value < 0.3)
                    Fish.fishID = "Golden Cod";  // 250 gold + 125 XP
                else if (UnityEngine.Random.value < 0.1)
                    Fish.fishID = "Diamond Angler Fish";  // 1250 gold + 1250 XP
                break;

            case "Junk":  // JUNK LOOT TABLE:

                Fish.fishID = "Fish Bait";  // by default, start by assuming we caught Fish Bait. (2X fishing speed, fish more likely)

                // RNG determines whether or not we get different kinda junk..
                if (UnityEngine.Random.value < 0.5)
                    Fish.fishID = "Junk Bait";  // 2X fishing speed, junk more likely
                else if (UnityEngine.Random.value < 0.25)
                    Fish.fishID = "Treasure Bait";  // 2X fishing speed, treasure more likely
                else if (UnityEngine.Random.value < 0.1)
                    Fish.fishID = "Sea Monster Bait";  // 2X fishing speed, sea monster more likely
                break;

            case "Treasure":  // TREASURE LOOT TABLE:

                Fish.fishID = "Lucky Diamond";  // by default, start by assuming we caught Lucky Diamond. (5000 gold + 5000 XP)

                // RNG determines whether or not we get different kinda treasure..
                if (UnityEngine.Random.value < 0.25)
                    Fish.fishID = "Super All-Rounder Bait";  // 4X fishing speed, best loot table drops guaranteed, treasure WAY more likely.
                else if (UnityEngine.Random.value < 0.25)
                    Fish.fishID = "Permanent Gold & XP Boost";  // depends on fishing level
                else if (UnityEngine.Random.value < 0.25)
                    Fish.fishID = "Ominous Shadow Onus";  // permanently increases chance of catching Nightmare Orb..
                break;

            case "Sea Monster":  // SEA MONSTER LOOT TABLE:

                Fish.fishID = "Deep Sea Shark";  // by default, start by assuming we caught a Deep Sea Shark. (BUTTON SPAM QTE)

                // RNG determines whether or not we get different kinda sea monsters..
                if (UnityEngine.Random.value < 0.25)
                    Fish.fishID = "Spike Anvil";  // DODGE QTE
                else if (UnityEngine.Random.value < 0.25)
                    Fish.fishID = "Sword Monster";  // PARRY QTE
                else if (UnityEngine.Random.value < 0.25)
                    Fish.fishID = "Lucid Dream Siren";  // PARAPPA QTE
                break;

            case "Nightmare Orb":  // NIGHTMARE ORB!... Is technically just an orb, so..
                Fish.fishID = "Nightmare Orb";
                break;
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
        if (!fishingLeft)
        {
            Player.TPToRightFishingSpot = true;  // trigger TPToRightFishingSpot variable in Player.cs, which teleports player to right fishing spot..
            playerAnim.Play("playerSwingBack");  // RIGHT FISHING -> stick to default animation!
        }
        else
        {
            Player.TPToLeftFishingSpot = true;  // trigger TPToLeftFishingSpot variable in Player.cs, which teleports player to left fishing spot..
            playerAnim.Play("LeftSwingBack");  // LEFT FISHING -> use left version instead!
        }

        yield return new WaitForSeconds(0.25f);
        
        Debug.Log("Line casted! And now, we wait for fish..");

        yield return new WaitForSeconds(1.5f);

        // FISHING SPEED RNG!
        bool waitingForFish = true;

        while (waitingForFish)  // every 3 second interval, run a x% chance to advance to "FishBitTheHook()" stage!
        {
            if (UnityEngine.Random.value < 0.5)  // 50% chance.
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

            // FISH BITES HOOK ANIMATION GETS TRIGGERED!
            if (!fishingLeft)
                playerAnim.Play("FishBitesHook");  // RIGHT FISHING -> stick to default animation.
            else
                playerAnim.Play("LeftFishBitHook"); // LEFT FISHING -> use left version instead!

                Debug.Log("A fish has bitten the hook!! Press C to catch the fish!");

            yield return new WaitForSeconds(1f);  // wait 1.5 seconds for player to catch fish..

            if (caughtFish == "NotCaught" && fishingMode)  // if time runs out, and player still hasn't caught the fish..
            {
                // turn fishing mode OFF and reset caughtFish to "N/A".
                fishingMode = false;
                caughtFish = "N/A";
                
                // the fish gets bored and escapes! womp womp..
                if (!fishingLeft)
                    playerAnim.Play("playerIdle");  // RIGHT FISHING -> stick to default animation.
                else
                    playerAnim.Play("LeftIdle");  // LEFT FISHING -> use left version instead!

                Debug.Log("Oh no! The fish got away!");
            }
        }
    }
}
