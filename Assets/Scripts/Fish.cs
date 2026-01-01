using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // FISH -> CHANGE CAUGHT FISH OBJECT'S SPRITE BASED ON WHAT THE PLAYER CAUGHT (FISH ID)
    public static string fishID = "Fish";

    // SETTING UP SPRITE RENDERER
    public SpriteRenderer spriteRenderer;
    
    // FISH SPRITE VARIABLE
    public Sprite fishSprite;
    // JUNK SPRITE VARIABLE
    public Sprite junkSprite;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(fishID)
        {
            case "Fish":  // FISH ID
                spriteRenderer.sprite = fishSprite;  // change object to fish sprite
                break;
            case "Junk":  // JUNK ID
                spriteRenderer.sprite = junkSprite;  // change object to junk sprite
                break;
        }
    }
}
