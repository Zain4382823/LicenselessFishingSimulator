using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region Declare Variables

    // GOLD SUM -> How much gold will the player get from selling something?
    int Goldsum = 0;

    // SELECTED BAIT -> Helps us keep track of which bait type we're buying / selling!
    public static string SelectedBait = "Fish";

    // SELECTED ROD UPGRADE -> Helps us keep track of which rod upgrade they're buying!
    public static string SelectedRodUpgrade = "Efficiency";

    // EFFICIENCY: Faster fishing speed!
    int efficiencyLV = 0;

    // MULTI-CATCH: Catch multiple fish at once!
    int multiCatchLV = 0;

    // AUTO-CATCH: You no longer have to press F, fish get caught automatically!
    bool autoCatch = false;

    // WATER LEVEL: Keeps track of current water level, for upgrade purchase-related reasons!
    int waterLevel = 1;

    #endregion

    #region Start() + Update() + Collision Check

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // PLAYER COLLIDES WITH SHOP = OPEN MAIN SHOP MENU!
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // When player walks into the shop, load up the main shop menu!
        {
            MainMenu();
        }
    }

    #endregion

    #region All Print Menus!

    // MAIN MENU -> First, let's ask the player if they want to buy or sell items!
    void MainMenu()
    {
        Console.WriteLine("BUY or SELL? \n" +
            "(Q -> Buy Menu | E -> Sell Menu)");
    }

    // BUY MENU -> Display all the items you can buy, including the price!
    void BuyMenu()
    {
        Console.WriteLine("BUY ITEMS:\n" +
            "[1] -> Baits!\n" +
            "[2] -> Fishing Rod Upgrades!\n" +
            "[3] -> Water Upgrades! (750G)\n" +
            "[4] -> Ominous Shadow Onus! (2000G)\n");
    }

    // SELL MENU -> Display all the items you can sell, including the price!
    void SellMenu()
    {
        Console.WriteLine("SELL ITEMS:\n" +
            "[1] -> Fish!\n" +
            "[2] -> Baits!\n" +
            "[3] -> Lucky Diamonds! (5000G + 5000XP)\n");
    }

    // BUY BAIT MENU -> Print all bait types and their buying price!
    void BuyBaitMenu()
    {
        Console.WriteLine("BUY BAITS:\n" +
            "[1] -> Fish Bait! (250G)\n" +
            "[2] -> Junk Bait! (250G)\n" +
            "[3] -> Treasure Bait!(500G)\n" +
            "[4] -> Sea Monster Bait! (500G)\n" +
            "[5] -> Super All-Rounder Bait! (750G)\n");
    }

    // SELL BAIT MENU -> Print all bait types and their selling price!
    void SellBaitMenu()
    {
        Console.WriteLine("BUY BAITS:\n" +
            "[1] -> Fish Bait! (200G + 75XP)\n" +
            "[2] -> Junk Bait! (200G + 75XP)\n" +
            "[3] -> Treasure Bait! (400G + 150XP)\n" +
            "[4] -> Sea Monster Bait! (400G + 150XP)\n" +
            "[5] -> Super All-Rounder Bait! (600G + 300XP)\n");
    }

    // BUY ROD UPGRADES MENU -> Print all rod upgrades and their price! (N)
    void BuyRodUpgradesMenu()
    {
        Console.WriteLine("SELL ITEMS:\n" +
            "[1] -> Efficiency! (500G)\n" +
            "[2] -> Multi-Catch! (1500G)\n" +
            "[3] -> Auto-Catch! (750G)\n");
    }

    #endregion

    #region SHOP METHODS - BUY SIDE!:

    // BUY BAITS -> Here, we buy a specific bait depending on what the player selected!
    void BuyBaits()
    {
        switch(SelectedBait)
        {
            case "Fish":
                Progression.gold -= 250;  // -250 Gold
                Bait.FishBaitCount++;  // +1 Fish Bait
                break;
            case "Junk":
                Progression.gold -= 250;  // -250 Gold
                Bait.JunkBaitCount++;  // +1 Junk Bait
                break;
            case "Treasure":
                Progression.gold -= 500;  // -500 Gold
                Bait.TreasureBaitCount++;  // +1 Treasure Bait
                break;
            case "Sea Monster":
                Progression.gold -= 500;  // -500 Gold
                Bait.SeaMonsterBaitCount++;  // +1 Sea Monster Bait
                break;
            case "Super All-Rounder":
                Progression.gold -= 750;  // -750 Gold
                Bait.SuperAllRounderBaitCount++;  // +1 Super All-Rounder Bait
                break;
        }
    }

    // BUY ROD UPGRADES -> Implement an upgrade based on what the player selected! (Upgrade variables needed here..)
    void BuyRodUpgrades()
    {
        switch(SelectedRodUpgrade)
        {
            case "Efficiency":
                Progression.gold -= 500;  // -500 Gold
                Progression.fishingSpeed -= 0.15f;  // Faster fishing speed!
                // (DO LATER) -> CREATE NEW VARIABLE IN PROGRESSION.CS FOR MIN FISHING SPEED & REDUCE IT HERE AS A BONUS!
                efficiencyLV++;  // Check this variable, to make sure they can't buy again when it's max level.
                break;
            case "Multi-Catch":
                Progression.gold -= 1500;  // -1500 Gold
                multiCatchLV++;  // Check this variable when catching fish, do a while loop!
                break;
            case "Auto-Catch":
                Progression.gold -= 750;  // -750 Gold
                autoCatch = true;  // Check this variable when a fish bites the hook, do an if statement!
                break;
        }
    }

    // BUY WATER UPGRADES -> Using a water level variable, upgrade water level until it's max level!
    void BuyWaterUpgrades()
    {
        // UPGRADE PRICE -> 750 Increments with each upgrade! (750G, 1500G, 2250G, 3000G)
        Goldsum = 750 * waterLevel;
        Progression.gold -= Goldsum;  // Player loses Goldsum amount of gold!

        // WATER UPGRADE -> Permanently improved drops!
        Fishing.fishRNG -= 0.05f;  // less fish..
        Fishing.treasureRNG += 0.05f;  // more treasure..
        Fishing.nightmareOrbRNG /= 10;  // nightmare orb more likely..

        // INCREASE WATER LEVEL
        waterLevel++;
    }

    // BUY SHADOW ONUS -> This is a permanent upgrade they can buy infinitely, it slightly increases Nightmare Orb drop rate!
    void BuyShadowOnus()
    {
        Progression.gold -= 2000;  // -2000 Gold
        Fishing.nightmareOrbRNG /= 100;  // Increases Nightmare Orb considerately!
    }

    #endregion

    #region SHOP METHODS - SELL SIDE!:

    // SELL FISH -> Here, we automatically sell all of the fish + lucky diamonds in player's inventory!
    void SellFish()
    {
        // SELL ALL FISH - THE ULTIMATE EQUATION!
        Goldsum = (50 * Fishing.SaltWaterTroutCount) + (100 * Fishing.SilverSalmonCount) + (250 * Fishing.GoldenCodCount) + (1250 * Fishing.DiamondAnglerCount);

        // ADD GOLD SUM TO GOLD COUNT!
        Progression.gold += Goldsum;

        // RESET FISH COUNTS!
        Fishing.SaltWaterTroutCount = 0;   Fishing.SilverSalmonCount = 0;
        Fishing.GoldenCodCount = 0;        Fishing.DiamondAnglerCount = 0;
    }

    // SELL BAITS -> Here, we sell a specific type of bait, depending on what the player selected! (Switch statement time!)
    void SellBaits()
    {
        // SWITCH STATEMENT FOR EACH BAIT TYPE
        switch (SelectedBait)
        {
            case "Fish":
                Goldsum = (200 * Bait.FishBaitCount);    // calculate the sum of gold we'll get by selling all baits! e.g (200 x 3 = 600 gold)
                Progression.gold += Goldsum;             // add calculated sum of gold to player's wallet, so to speak!
                Bait.FishBaitCount = 0;                 // reset bait count, all of it has been SOLD!
                break;
            case "Junk":
                Goldsum = (200 * Bait.JunkBaitCount);    // calculate the sum of gold we'll get by selling all baits! e.g (200 x 3 = 600 gold)
                Progression.gold += Goldsum;             // add calculated sum of gold to player's wallet, so to speak!
                Bait.JunkBaitCount = 0;                 // reset bait count, all of it has been SOLD!
                break;
            case "Treasure":
                Goldsum = (400 * Bait.TreasureBaitCount);    // calculate the sum of gold we'll get by selling all baits! e.g (400 x 3 = 1200 gold)
                Progression.gold += Goldsum;                 // add calculated sum of gold to player's wallet, so to speak!
                Bait.TreasureBaitCount = 0;                 // reset bait count, all of it has been SOLD!
                break;
            case "Sea Monster":
                Goldsum = (400 * Bait.SeaMonsterBaitCount);    // calculate the sum of gold we'll get by selling all baits! e.g (400 x 3 = 1200 gold)
                Progression.gold += Goldsum;                   // add calculated sum of gold to player's wallet, so to speak!
                Bait.SeaMonsterBaitCount = 0;                 // reset bait count, all of it has been SOLD!
                break;
            case "All-Rounder":
                Goldsum = (600 * Bait.SuperAllRounderBaitCount);    // calculate the sum of gold we'll get by selling all baits! e.g (600 x 3 = 1800 gold)
                Progression.gold += Goldsum;                        // add calculated sum of gold to player's wallet, so to speak!
                Bait.SuperAllRounderBaitCount = 0;                 // reset bait count, all of it has been SOLD!
                break;
        }
    }

    #endregion
}
