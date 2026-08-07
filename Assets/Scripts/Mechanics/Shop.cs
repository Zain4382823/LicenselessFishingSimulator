using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region Declare Variables

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

    }

    // SELL MENU -> Display all the items you can sell, including the price!
    void SellMenu()
    {

    }

    // BUY BAIT MENU -> Print all bait types and their buying price!
    void BuyBaitMenu()
    {

    }

    // SELL BAIT MENU -> Print all bait types and their selling price!
    void SellBaitMenu()
    {

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

    }

    // SELL BAITS -> Here, we sell a specific type of bait, depending on what the player selected! (Switch statement time!)
    void SellBaits()
    {

    }

    #endregion
}
