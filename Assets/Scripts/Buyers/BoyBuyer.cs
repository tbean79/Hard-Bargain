using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyBuyer : Buyer
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
            case UnicornItem u:
                perceivedValue = 20;
                break;
            case BlanketItem b:
                perceivedValue = 30;
                break;
            case WoodenSwordItem w:
                perceivedValue = 75;
                break;
            case CharmBraceletItem c:
                perceivedValue = 35;
                break;
            case SupremeTeeItem s:
                perceivedValue = 50;
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
