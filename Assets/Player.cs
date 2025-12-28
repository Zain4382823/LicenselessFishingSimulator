using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool fishingMode = false;
    bool fishingModeCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Currently idle..");
        Debug.Log("(Press F to enter fishing mode!)");
    }

    // Update is called once per frame
    void Update()
    {
        // Handle F key inputs -> Enter / Exit Fishing Mode!
        if (Input.GetKey(KeyCode.F))
        {
            if (!fishingMode && !fishingModeCooldown)  // if fishing mode is off, and no cooldown..
            {
                // turn fishing mode ON!!
                fishingMode = true;
                Debug.Log("Fishing Mode activated!");
                // activate cooldown to prevent spamming + start timer to deactivate cooldown after a few seconds..
                fishingModeCooldown = true;
                StartCoroutine(FishModeCDTimer());
            }
            else if (fishingMode && !fishingModeCooldown)  // if fishing mode is on, and no cooldown..
            {
                // turn fishing mode OFF!!
                fishingMode = false;
                Debug.Log("Fishing Mode deactivated!");
                // activate cooldown to prevent spamming + start timer to deactivate cooldown after a few seconds..
                fishingModeCooldown = true;
                StartCoroutine(FishModeCDTimer());
            }
        }
    }

    // COOLDOWN TIMER -> player is not allowed to spam F key, must wait a bit before toggling fishing mode ON / OFF!
    IEnumerator FishModeCDTimer()
    {
        yield return new WaitForSeconds(1);
        fishingModeCooldown = false;
    }
}
