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
        Console.WriteLine("BUY or SELL? \n (Q -> Buy Menu | E -> Sell Menu)");
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

    }

    // BUY ROD UPGRADES -> Implement an upgrade based on what the player selected! (Upgrade variables needed here..)
    void BuyRodUpgrades()
    {

    }

    // BUY WATER UPGRADES -> Using a water level variable, upgrade water level until it's max level!
    void BuyWaterUpgrades()
    {

    }

    // BUY SHADOW ONUS -> This is a permanent upgrade they can buy infinitely, it slightly increases Nightmare Orb drop rate!
    void BuyShadowOnus()
    {

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
                Goldsum = (200 * Bait.FishBaitCount);    // calculate the sum of gold we'll get buy selling all baits! e.g (200 x 3 = 600 gold)
                Progression.gold += Goldsum;             // add calculated sum of gold to player's wallet, so to speak!
                Bait.FishBaitCount = 0;                 // reset bait count, all of it has been SOLD!
                break;
            case "Junk":
                Goldsum = (200 * Bait.JunkBaitCount);    // calculate the sum of gold we'll get buy selling all baits! e.g (200 x 3 = 600 gold)
                Progression.gold += Goldsum;             // add calculated sum of gold to player's wallet, so to speak!
                Bait.JunkBaitCount = 0;                 // reset bait count, all of it has been SOLD!
                break;
            case "Treasure":
                Goldsum = (400 * Bait.TreasureBaitCount);    // calculate the sum of gold we'll get buy selling all baits! e.g (400 x 3 = 1200 gold)
                Progression.gold += Goldsum;                 // add calculated sum of gold to player's wallet, so to speak!
                Bait.TreasureBaitCount = 0;                 // reset bait count, all of it has been SOLD!
                break;
            case "Sea Monster":
                Goldsum = (400 * Bait.SeaMonsterBaitCount);    // calculate the sum of gold we'll get buy selling all baits! e.g (400 x 3 = 1200 gold)
                Progression.gold += Goldsum;                   // add calculated sum of gold to player's wallet, so to speak!
                Bait.SeaMonsterBaitCount = 0;                 // reset bait count, all of it has been SOLD!
                break;
            case "All-Rounder":
                Goldsum = (600 * Bait.SuperAllRounderBaitCount);    // calculate the sum of gold we'll get buy selling all baits! e.g (600 x 3 = 1800 gold)
                Progression.gold += Goldsum;                        // add calculated sum of gold to player's wallet, so to speak!
                Bait.SuperAllRounderBaitCount = 0;                 // reset bait count, all of it has been SOLD!
                break;
        }
    }

    #endregion
}
