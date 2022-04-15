using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreacherBuyer : Buyer
{
    // Start is called before the first frame update
    void Start()
    {
        moneyInPocket = 160;
        utilityScore = 150;
        acceptString = "Peace be with you";
        rejectString = "(He brushed the dust off his shoes and walked off)";
        counterStrings = new string[]{
            "I'm but a lonely servant of the Most High.  I beseech you, take {0}.",
            "I'm only carrying {0} on me, will you take that?"
        };
        highballString = "Are you trying to rip off a clergyman?  {0}, my brother.";
    }

    public override void SetPerceivedValue(Item item)
    {
        switch(item)
        {
            case UnicornItem u:
                perceivedValue = 40;
                break;
            case BlanketItem b:
                perceivedValue = 40;
                break;
            case WoodenSwordItem w:
                perceivedValue = 40;
                break;
            case CharmBraceletItem c:
                perceivedValue = 80;
                break;
            case SupremeTeeItem s:
                perceivedValue = 60;
                break;
            default:
                perceivedValue = 40;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
