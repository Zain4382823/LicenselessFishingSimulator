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
        // PRESSING B OPENS / CLOSES THE BAIT MENU!!
        if (Input.GetKeyDown(KeyCode.B))
        {
            // if & else statements for open / close checks!!
            if (!BaitMenuOpen) // CLOSE CHECK FIRST
            {
                // OPEN THE BAIT MENU!
                Debug.Log("Bait Menu Opened!");
                BaitMenuOpen = true;
            }
            else  // OPEN CHECK AFTER
            {
                // CLOSE THE BAIT MENU!
                Debug.Log("Bait Menu Closed!");
                BaitMenuOpen = false;
            }
        }
    }
}
