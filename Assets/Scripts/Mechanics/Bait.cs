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

    // which option number did the player select?
    int SelectedBaitOption = 1;

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
        yield return new WaitForSeconds(1);
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
                // Load up UseBait Enum -> Decrement FishBaitCount -> Debug Log message confirmation
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
