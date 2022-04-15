using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenCanvas : CanvasComp
{

    protected override void GameManagerOnGameStateChanged(GameState state) {
        CanvasObj.SetActive(state == GameState.StartScreen);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            GameManager.Instance.UpdateGameState(GameState.BuyerSelect);
        }
    }
}
