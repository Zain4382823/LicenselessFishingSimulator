using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepSeaShark : MonoBehaviour
{
    // isActive values:  [0] -> Not active  [1] -> Activation triggered  [2] -> Active
    public static int isActive = 0;

    // STRUGGLEPOINTS -> COUNTS HOW MANY TIMES PLAYER MASHES LEFT CLICK DURING QTE!
    int strugglePoints = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ButtonMashQTE()
    {
        yield return new WaitForSeconds(4f);
    }
}
