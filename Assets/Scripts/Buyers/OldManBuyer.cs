using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManBuyer : Buyer
{
    // Start is called before the first frame update
    void Start()
    {
        moneyInPocket = 160;
        utilityScore = 70;
        acceptString = "Sounds good.  Oh my grandchild will love this";
        rejectString = "I think I'll just be on my way.  Thanks";
        counterStrings = new string[]{
            "(He furrows his brow) Will you take {0}?",
            "I'll be in trouble with the wife if I spend that much.  How about {0}?"
        };
        highballString = "Heh heh, that's funny, young man.  {0}";
    }

    public override void SetPerceivedValue(Item item)
    {
        switch(item)
        {
            case UnicornItem u:
                perceivedValue = 75;
                break;
            case BlanketItem b:
                perceivedValue = 70;
                break;
            case WoodenSwordItem w:
                perceivedValue = 20;
                break;
            case CharmBraceletItem c:
                perceivedValue = 120;
                break;
            case SupremeTeeItem s:
                perceivedValue = 60;
                break;
            default:
                perceivedValue = 90;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
