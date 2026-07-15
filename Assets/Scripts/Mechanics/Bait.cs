using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour
{

    #region DeclareVariables

    // is the menu open?
    bool BaitMenuOpen = false;

    // is a bait currently being used?
    bool BaitActive = false;

    // which option did the player select?
    string SelectedBaitOption = "Fish";

    // INDIVIDUAL BAIT COUNTERS:
    int FishBaitCount = 1; int JunkBaitCount = 1; int TreasureBaitCount = 1; int SeaMonsterBaitCount = 1; int SuperAllRounderBaitCount = 1;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if player pressed B to open / close the bait menu!
        MenuOpenInputCheck();

        // check if player selected any number options! (1-5)
        OptionSelectCheck();
    }

    IEnumerator UseBait()
    {
        BaitActive = true;

        // APPLY BAIT EFFECTS! (Switch statement)
        switch(SelectedBaitOption)
        {
            case "Fish":  // 300% Fishing Speed, +15% More Likely To Catch Fish
                Progression.fishingSpeed /= 3;
                Fishing.fishRNG *= 1.15f;
                break;
            case "Junk":  // 200% Fishing Speed, +50% More Likely To Catch Junk
                Progression.fishingSpeed /= 2;
                Fishing.junkRNG *= 1.5f;
                break;
            case "Treasure":  // 200% Fishing Speed, +50% More Likely To Catch Treasure
                Progression.fishingSpeed /= 2;
                Fishing.treasureRNG *= 1.5f;
                break;
            case "Sea Monster":  // 200% Fishing Speed, +50% More Likely To Catch Sea Monster
                Progression.fishingSpeed /= 2;
                Fishing.seaMonsterRNG *= 1.5f;
                break;
            case "Super All-Rounder":  // 400% Fishing Speed, +100% More Likely To Catch Treasure, Best Drops Guaranteed!
                Progression.fishingSpeed /= 4;
                Fishing.treasureRNG *= 2f;
                break;
        }

        // bait lasts for 15 seconds, so we wait for 15 seconds..
        yield return new WaitForSeconds(15);

        BaitActive = false;

        // REMOVE BAIT EFFECTS! (Switch statement)
        switch (SelectedBaitOption)
        {
            case "Fish":  // -300% Fishing Speed, -15% LESS Likely To Catch Fish
                Progression.fishingSpeed *= 3;
                Fishing.fishRNG /= 1.15f;
                break;
            case "Junk":  // -200% Fishing Speed, -50% LESS Likely To Catch Junk
                Progression.fishingSpeed *= 2;
                Fishing.junkRNG /= 1.5f;
                break;
            case "Treasure":  // -200% Fishing Speed, -50% LESS Likely To Catch Treasure
                Progression.fishingSpeed *= 2;
                Fishing.treasureRNG /= 1.5f;
                break;
            case "Sea Monster":  // -200% Fishing Speed, -50% LESS Likely To Catch Sea Monster
                Progression.fishingSpeed *= 2;
                Fishing.seaMonsterRNG /= 1.5f;
                break;
            case "Super All-Rounder":  // -400% Fishing Speed, -100% LESS Likely To Catch Treasure, Normal Drops
                Progression.fishingSpeed *= 4;
                Fishing.treasureRNG /= 2f;
                break;
        }
    }

    void MenuOpenInputCheck()
    {
        // PRESSING B OPENS / CLOSES THE BAIT MENU!!
        if (Input.GetKeyDown(KeyCode.B))
        {
            // if & else statements for open / close checks!!
            if (!BaitMenuOpen) // CLOSE CHECK FIRST
            {
                // OPEN THE BAIT MENU!
                Debug.Log("Bait Menu Opened!");
                BaitMenuOpen = true;
                // DISPLAY MENU!
                MenuDisplay();
            }
            else  // OPEN CHECK AFTER
            {
                // CLOSE THE BAIT MENU!
                Debug.Log("Bait Menu Closed!");
                BaitMenuOpen = false;
            }
        }
    }

    void OptionSelectCheck()
    {
        // INPUT CHECK 1 - Fish Bait
        if (Input.GetKeyDown(KeyCode.Alpha1) && BaitMenuOpen)
        {
            if (FishBaitCount > 0)
            {
                // SelectedBait = "Fish" -> Load up UseBait Enum -> Decrement FishBaitCount -> Debug Log message confirmation
                SelectedBaitOption = "Fish";
                UseBait();
                FishBaitCount--;
                Debug.Log("You used a fish bait!");
            }
            else
            {
                Debug.Log("You don't have any fish baits!");
            }
        }

        // INPUT CHECK 2 - Junk Bait
        if (Input.GetKeyDown(KeyCode.Alpha2) && BaitMenuOpen)
        {
            if (JunkBaitCount > 0)
            {
                // Load up UseBait Enum -> Decrement JunkBaitCount -> Debug Log message confirmation
                SelectedBaitOption = "Junk";
                UseBait();
                JunkBaitCount--;
                Debug.Log("You used a junk bait!");
            }
            else
            {
                Debug.Log("You don't have any junk baits!");
            }
        }

        // INPUT CHECK 3 - Treasure Bait
        if (Input.GetKeyDown(KeyCode.Alpha3) && BaitMenuOpen)
        {
            if (TreasureBaitCount > 0)
            {
                // Load up UseBait Enum -> Decrement TreasureBaitCount -> Debug Log message confirmation
                SelectedBaitOption = "Treasure";
                UseBait();
                TreasureBaitCount--;
                Debug.Log("You used a treasure bait!");
            }
            else
            {
                Debug.Log("You don't have any treasure baits!");
            }
        }

        // INPUT CHECK 4 - Sea Monster Bait
        if (Input.GetKeyDown(KeyCode.Alpha4) && BaitMenuOpen)
        {
            if (SeaMonsterBaitCount > 0)
            {
                // Load up UseBait Enum -> Decrement SeaMonsterBaitCount -> Debug Log message confirmation
                SelectedBaitOption = "Sea Monster";
                UseBait();
                SeaMonsterBaitCount--;
                Debug.Log("You used a sea monster bait!");
            }
            else
            {
                Debug.Log("You don't have any sea monster baits!");
            }
        }

        // INPUT CHECK 5 - Super AllRounder Bait
        if (Input.GetKeyDown(KeyCode.Alpha5) && BaitMenuOpen)
        {
            if (SuperAllRounderBaitCount > 0)
            {
                // Load up UseBait Enum -> Decrement SuperAllRounderBaitCount -> Debug Log message confirmation
                SelectedBaitOption = "Super All-Rounder";
                UseBait();
                SuperAllRounderBaitCount--;
                Debug.Log("You used a super all-rounder bait!");
            }
            else
            {
                Debug.Log("You don't have any super all-rounder baits!");
            }
        }
    }

    void MenuDisplay()
    {
        Debug.Log("SELECT YOUR BAIT:" +
            "\n (1) - Fish Bait \n (2) - Junk Bait \n (3) - Treasure Bait \n (4) - Sea Monster Bait \n (5) - Super All-Rounder Bait");
    }
}
