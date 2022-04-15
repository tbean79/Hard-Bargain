using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBuyer : Buyer
{
    // Start is called before the first frame update
    void Start()
    {
        moneyInPocket = 100;
        utilityScore = 70;
        acceptString = "Now you're speakin' my language.  I'll take it!";
        rejectString = "No chance, bub.  Maybe next time";
        counterStrings = new string[]{
            "No, I kinda just came here to get lettuce.  But if you went down to {0}, I would consider it"
        };
        highballString = "What are you trying to pull?  That's still too high.  What about {0}?";
    }

    public override void SetPerceivedValue(Item item)
    {
        switch(item)
        {
            case CubeItem c:
                perceivedValue = 80;
                break;
            case SphereItem s:
                perceivedValue = 15;
                break;
            case CylinderItem cy:
                perceivedValue = 30;
                break;
            default:
                perceivedValue = 60;
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
