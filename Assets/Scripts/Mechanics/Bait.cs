using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour
{
    // is the menu open?
    bool BaitMenuOpen = false;

    // is a bait currently being used?
    bool BaitActive = false;

    // which option number did the player select?
    int SelectedBaitOption = 1;

    // INDIVIDUAL BAIT COUNTERS:
    int FishBaitCount = 1; int JunkBaitCount = 1; int TreasureBaitCount = 1; int SeaMonsterBaitCount = 1; int SuperAllRounderBaitCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if player pressed B to open / close the bait menu!
        MenuOpenInputCheck();

        // INPUT CHECK 1 - Fish Bait
        if (Input.GetKeyDown(KeyCode.Alpha1) && BaitMenuOpen)
        {
            if (FishBaitCount > 0)
            {
                // Load up UseBait Enum -> Decrement FishBaitCount -> Debug Log message confirmation
                UseBait();
                FishBaitCount--;
                Debug.Log("You used a Fish Bait!");
            }
            else
            {
                Debug.Log("You don't have any fish baits!");
            }
        }
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

    void MenuDisplay()
    {
        Debug.Log("SELECT YOUR BAIT:" +
            "\n (1) - Fish Bait \n (2) - Junk Bait \n (3) - Treasure Bait \n (4) - Sea Monster Bait \n (5) - Super All-Rounder Bait");
    }
}
