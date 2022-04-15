using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigManBuyer : Buyer
{
    // Start is called before the first frame update
    void Start()
    {
        moneyInPocket = 100;
        utilityScore = 70;
        acceptString = "Now you're speakin' my language.  I'll take it!";
        rejectString = "No chance, bub.  Maybe next time";
        counterStrings = new string[]{
            "No, I kinda just came here to get lettuce.  But if you went down to {0}, I would consider it",
            "Listen, it's getting late.  What about {0}."
        };
        highballString = "What are you trying to pull?  That's still too high.  What about {0}?";
    }

    public override void SetPerceivedValue(Item item)
    {
        switch(item)
        {
            case UnicornItem u:
                perceivedValue = 20;
                break;
            case BlanketItem b:
                perceivedValue = 45;
                break;
            case WoodenSwordItem w:
                perceivedValue = 15;
                break;
            case CharmBraceletItem c:
                perceivedValue = 60;
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
