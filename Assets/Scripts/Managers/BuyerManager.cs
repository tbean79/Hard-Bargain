using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerManager : MonoBehaviour
{
    int? startingCounteroffer; // maybe move this to Buyer class
    int? previousCounteroffer;
    int? previousOffer;

    private Buyer currentBuyer;
    private Item currentItem;

    public event Action<string, int, bool> OnReadyToPaintToCanvas;

    const int DROP_IF_NOT_LOWER = 50;
    const int MIN_COUNTEROFFER = 20;

    System.Random rand = new System.Random();

    public GameObject BuyerPlacementPoint;
    public GameObject ItemPlacementPoint;

    public BuyerSelector BuyerSelector;
    public ItemSelector ItemSelector;

    // protected virtual void Awake() {
    //     GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    // }

    // protected virtual void OnDestroy() {
    //     GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    // }

    // protected void GameManagerOnGameStateChanged(GameState state) {
    //     // if (state == GameState.BeginHaggle) {
    //     //     ItemSelector ItemSelector = (ItemSelector)buyerManager.GetComponent(typeof(ItemSelector));
    //     //     currentItem = (Item)ItemSelector.GetSelectedObject();
    //     //     BuyerSelector BuyerSelector = (BuyerSelector)buyerManager.GetComponent(typeof(BuyerSelector));
    //     //     currentBuyer = (Buyer)BuyerSelector.GetSelectedObject();
    //     //     currentBuyer.SetPerceivedValue(currentItem);

    //     //     GameManager.Instance.UpdateGameState(GameState.Offer);
    //     // }

    //     if (state == GameState.Decide) {
    //         //zero out this.current vars and currentBuyer. vars
    //     }
    // }

    public void OnBuyerSelect(Buyer buyer) {
        currentBuyer = buyer;
        currentBuyer.transform.position = BuyerPlacementPoint.transform.position;
    }

    public void OnItemSelect(Item item) {
        currentItem = item;
        currentItem.transform.position = new Vector3(
            ItemPlacementPoint.transform.position.x, ItemPlacementPoint.transform.position.y + 1, ItemPlacementPoint.transform.position.z);
        currentItem.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
        currentBuyer.SetPerceivedValue(currentItem);
    }

    public void OnOffer(int offer) {
        // to create delay, you'd need a ref to counteroffer canvas
        

        // if offer is below perceived value, accept
        if (offer <= currentBuyer.GetPerceivedValue() || offer <= previousCounteroffer) {
            OnReadyToPaintToCanvas?.Invoke(currentBuyer.acceptString, offer, true);
            // skip past offer state
            return;
        }

        ////////////////////////////////

        // they are done going back and forth with you
        if (currentBuyer.utilityScore <= 0) {
            OnReadyToPaintToCanvas?.Invoke("They left", 0, true);

            return;
        }

        // lower score by a lot if not a large enough drop
        if (previousOffer != null && offer >= previousOffer) {
            currentBuyer.utilityScore -= DROP_IF_NOT_LOWER;
            OnReadyToPaintToCanvas?.Invoke(currentBuyer.highballString, (int)previousCounteroffer, false);


            return;
        }
        /////////////////////////////////////

        int counterOffer;

        // when initializing, starting counteroffer should be the same space below as yours is above, 
        //add randomness, and minimum is 20
        if (startingCounteroffer == null) {
            var difference = offer - currentBuyer.GetPerceivedValue();
            counterOffer = Math.Max(currentBuyer.GetPerceivedValue() - difference, MIN_COUNTEROFFER);
            //counterOffer = Math.Min(counterOffer, currentBuyer.moneyInPocket);
            startingCounteroffer = counterOffer;
        }

        // if not, choose random increment based on score that's left (higher score means more likely to 
        // jump above perceived value), max is pocket value, choose counteroffer text option
        else {
            var increment = 2 * Math.Log(currentBuyer.utilityScore);
            counterOffer = (int)Math.Round((double) previousCounteroffer + increment, 0);
        }

        if (counterOffer >= offer) {
            OnReadyToPaintToCanvas?.Invoke(currentBuyer.acceptString, offer, true);
            // skip past offer state
            return;
        }
    
        var index = rand.Next(currentBuyer.counterStrings.Length);
        OnReadyToPaintToCanvas?.Invoke(currentBuyer.counterStrings[index], counterOffer, false);

        //check previous, initialize if empty
        previousOffer = offer;
        previousCounteroffer = counterOffer;
        currentBuyer.utilityScore -= 10;


        //throw in something where they push their luck, at some point in this algorithm

    }

    public void OnAcceptCounterOffer() {
    //         //zero out this.current vars and currentBuyer. vars
        ItemSelector.RemoveObjFromIterObjs(currentItem);
        ZeroOutVars();
    }

    public void OnRejectCounterOffer() {

    }

    protected void ZeroOutVars() {
        startingCounteroffer = null;
        previousCounteroffer = null;
        previousOffer = null;
        Console.WriteLine(currentBuyer.ToString());
        currentBuyer.SetPerceivedValue(null);
        currentBuyer = null;
        currentItem = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
