using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buyer : MonoBehaviour
{
    public int moneyInPocket;
    public int utilityScore {get; set;}
    public string acceptString;
    public string rejectString;
    public string[] counterStrings;
    public string highballString;
    
    protected int perceivedValue;

    public abstract void SetPerceivedValue(Item item);

    public int GetPerceivedValue() {
        return perceivedValue;
    }

}
