using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EldritchBuyer : Buyer
{
    // Start is called before the first frame update
    void Start()
    {
        moneyInPocket = 500;
        utilityScore = 10;
        acceptString = "(It nodded then vanished into the ground)";
        rejectString = "(It disappeared into the ground)";
        counterStrings = new string[]{
            "(It's glare is piercing your soul.  It's seeming to say, make it {0})"
        };
        highballString = "(It doesn't look too happy.  Better make it {0})";
    }

    public override void SetPerceivedValue(Item item)
    {
        switch(item)
        {
            case UnicornItem u:
                perceivedValue = 400;
                break;
            case BlanketItem b:
                perceivedValue = 250;
                break;
            case WoodenSwordItem w:
                perceivedValue = 70;
                break;
            case CharmBraceletItem c:
                perceivedValue = 160;
                break;
            case SupremeTeeItem s:
                perceivedValue = 200;
                break;
            default:
                perceivedValue = 180;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
