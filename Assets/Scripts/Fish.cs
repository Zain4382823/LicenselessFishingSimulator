using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // FISH -> CHANGE CAUGHT FISH OBJECT'S SPRITE BASED ON WHAT THE PLAYER CAUGHT!
    
    // Fish Type -> Fish? Junk? Treasure? each type has its own unique loot table!
    public static string fishType = "Fish";

    // Fish ID -> while FishType is the LOOT TABLE, FishID is the SPECIFIC ITEM we pick FROM THE LOOT TABLE!
    public static string fishID = "Saltwater Trout";

    // SETTING UP SPRITE RENDERER
    public SpriteRenderer spriteRenderer;
    
    // FISH SPRITE VARIABLE
    public Sprite fishSprite;
    // JUNK SPRITE VARIABLE
    public Sprite junkSprite;
    // TREASURE SPRITE VARIABLE
    public Sprite treasureSprite;
    // SEA MONSTER VARIABLE
    public Sprite seaMonsterSprite;
    // NIGHTMARE ORB VARIABLE
    public Sprite nightmareOrbSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(fishType)
        {
            case "Fish":  // we caught a FISH!
                spriteRenderer.sprite = fishSprite;  // change object to fish sprite
                break;
            case "Junk":  // we got JUNK!
                spriteRenderer.sprite = junkSprite;  // change object to junk sprite
                break;
            case "Treasure":  // we got TREASURE!
                spriteRenderer.sprite = treasureSprite;  // change object to treasure sprite
                break;
            case "Sea Monster": // we caught a SEA MONSTER!
                spriteRenderer.sprite = seaMonsterSprite;  // change object to sea monster sprite
                break;
            case "Nightmare Orb": // we got the NIGHTMARE ORB!
                spriteRenderer.sprite = nightmareOrbSprite;  // change object to nightmare orb sprite
                break;
        }
    }
}
