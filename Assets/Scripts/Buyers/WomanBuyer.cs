using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanBuyer : Buyer
{
    // Start is called before the first frame update
    void Start()
    {
        moneyInPocket = 250;
        utilityScore = 20;
        acceptString = "It's a deal.  (What a fool.  He'll go broke at this rate.)";
        rejectString = "I'm afraid I'll be taking my business elsewhere";
        counterStrings = new string[]{
            "But the old peddler by the bridge is selling the same thing for {0}",
            "Make no mistake, I could pay that, but it's insulting to overcharge me just cause I'm rich.  {0}.",
            "Nope, sweetie.  Make it {0}."
        };
        highballString = "{0}, take it or leave it.";
    }

    public override void SetPerceivedValue(Item item)
    {
        switch(item)
        {
            case UnicornItem u:
                perceivedValue = 200;
                break;
            case BlanketItem b:
                perceivedValue = 150;
                break;
            case WoodenSwordItem w:
                perceivedValue = 80;
                break;
            case CharmBraceletItem c:
                perceivedValue = 200;
                break;
            case SupremeTeeItem s:
                perceivedValue = 80;
                break;
            default:
                perceivedValue = 100;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
