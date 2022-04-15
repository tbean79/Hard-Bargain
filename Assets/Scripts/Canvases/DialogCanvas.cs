using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogCanvas : CanvasComp
{
    [SerializeField]
    public Button AcceptButton;

    [SerializeField]
    public Button RejectButton;

    [SerializeField]
    public Text textField;

    int lastCounteroffer;

    protected override void GameManagerOnGameStateChanged(GameState state) {
        CanvasObj.SetActive(state == GameState.CounterOffer);
        AcceptButton.Select();
    }

    void HandleAccept(GameObject obj) {
        if (RejectButton.gameObject.activeSelf == true) {
            GameManager.Instance.UpdateProfit(lastCounteroffer);
        }
        buyerManager.OnAcceptCounterOffer();
        GameManager.Instance.UpdateGameState(GameState.Decide);
    }

    void HandleReject(GameObject obj) {
        buyerManager.OnRejectCounterOffer();
        GameManager.Instance.UpdateGameState(GameState.Offer);
    }

    protected override void BuyerManagerOnReadyToPaintToCanvas(string text, int counterOffer, bool accepted) {
        lastCounteroffer = counterOffer;
        RejectButton.gameObject.SetActive(!accepted);

        if (!accepted) {
            textField.text = string.Format(text, counterOffer);
        } else {
            GameManager.Instance.UpdateProfit(counterOffer);
            textField.text = text;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AcceptButton.onClick.AddListener(delegate{HandleAccept(CanvasObj);});
        RejectButton.onClick.AddListener(delegate{HandleReject(CanvasObj);});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
