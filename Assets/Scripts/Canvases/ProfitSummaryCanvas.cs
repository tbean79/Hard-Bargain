using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfitSummaryCanvas : CanvasComp
{
    [SerializeField]
    Text profitText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void GameManagerOnGameStateChanged(GameState state) {
        profitText.text = "$" + GameManager.Instance.GetProfit();
        CanvasObj.SetActive(state == GameState.ProfitSummary);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
