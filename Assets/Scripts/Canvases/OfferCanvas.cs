using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfferCanvas : CanvasComp
{
    [SerializeField]
    public InputField InputFieldObj;

    protected override void GameManagerOnGameStateChanged(GameState state) {

        CanvasObj.SetActive(state == GameState.Offer);
        InputFieldObj.ActivateInputField();
    }

    void HandleOffer(InputField input) {
        int n;
        bool isNumeric = int.TryParse(input.text, out n);
        if (!isNumeric && n < 1) {
            input.text = null;
            input.ActivateInputField();
        }
        else {
            buyerManager.OnOffer(n);
            GameManager.Instance.UpdateGameState(GameState.CounterOffer);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InputFieldObj.onEndEdit.AddListener(delegate{HandleOffer(InputFieldObj);});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
