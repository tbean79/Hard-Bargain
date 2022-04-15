using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderBuyer : Buyer
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
            case CubeItem c:
                perceivedValue = 150;
                break;
            case SphereItem s:
                perceivedValue = 180;
                break;
            case CylinderItem cy:
                perceivedValue = 120;
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
