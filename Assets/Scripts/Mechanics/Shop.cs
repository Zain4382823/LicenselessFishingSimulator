using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // When player walks into the shop, load up the main shop menu!
        {
            MainMenu();
        }
    }

    // MAINMENU() -> First, let's ask the player if they want to buy or sell items!
    void MainMenu()
    {
        Console.WriteLine("BUY or SELL? \n (Q -> Buy Menu | E -> Sell Menu)");
    }
}
