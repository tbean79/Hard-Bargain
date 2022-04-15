using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBuyer : Buyer
{
    // Start is called before the first frame update
    void Start()
    {
        moneyInPocket = 50;
        utilityScore = 130;
        acceptString = "Deal.";
        rejectString = "I've, uh, got to go...";
        counterStrings = new string[]{
            "But I only have {0} with me."
        };
        highballString = "What?  That's what you said before.  What about {0}?";
    }

    public override void SetPerceivedValue(Item item)
    {
        switch(item)
        {
            case CubeItem c:
                perceivedValue = 80;
                break;
            case SphereItem s:
                perceivedValue = 70;
                break;
            case CylinderItem cy:
                perceivedValue = 100;
                break;
            default:
                perceivedValue = 50;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
