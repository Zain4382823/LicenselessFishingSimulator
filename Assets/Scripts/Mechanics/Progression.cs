using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    // LEVELLING SYSTEM VARIABLES
    public static int fishingLevel = 1;

    // player starts at level 1 with (0/requiredXP XP)
    public static float XP = 0;
    public static float requiredXP = 200;

    // the player starts off broke..
    public static int gold = 0;

    // FISHING SPEED -> The time interval between each fishing dice roll, levelling up reduces the time taken to catch fish!
    public static float fishingSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Handle L key input -> Player Level Status Check!
        if (Input.GetKeyDown(KeyCode.L))
            Debug.LogFormat("LEVEL {0}: \n({1} / {2} XP) and {3} Gold!", fishingLevel, XP, Math.Round(requiredXP), gold);

        // when player gets enough XP, they level up!
        if (XP >= requiredXP)
        {
            // LEVEL UP!!!

            // fishing speed increases, you wait less time for fish!
            if(fishingSpeed > 0.5)
                fishingSpeed -= 0.25f; // decrementing wait time by 0.25 seconds each time, let's cap it at 0.5 seconds for now..

            // increase the likelihood of catching Nightmare Orb!
            // NOTE: we'll do this one later...

            fishingLevel++;  // fishing level goes up!
            XP = 0;  // player's XP resets to zero
            requiredXP *= 2;  // you'll need a lot more XP to level up this time!
        }
    }
}
