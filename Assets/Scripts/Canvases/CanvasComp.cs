using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CanvasComp : MonoBehaviour
{
    [SerializeField]
    public GameObject CanvasObj;

    [SerializeField]
    public BuyerManager buyerManager;

    protected virtual void Awake() {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        buyerManager.OnReadyToPaintToCanvas += BuyerManagerOnReadyToPaintToCanvas;
    }

    protected virtual void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
        buyerManager.OnReadyToPaintToCanvas += BuyerManagerOnReadyToPaintToCanvas;
    }

    protected abstract void GameManagerOnGameStateChanged(GameState state);

    protected virtual void BuyerManagerOnReadyToPaintToCanvas(string text, int counterOffer, bool accepted) {
    }
}
