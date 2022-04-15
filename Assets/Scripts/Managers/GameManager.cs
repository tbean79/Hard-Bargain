using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int RoundNum = 1;
    private const int ROUND_TOTAL = 3;
    private GameState State;
    private int profit = 0;

    public static event Action<GameState> OnGameStateChanged;

    //Dictionary<State, List<State>> a nice idea, these are transition states

    void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newState) {
        State = newState;

        switch(newState) {
            case GameState.StartScreen:
                //add function handler here
                break;
            case GameState.BuyerSelect:
                break;
            case GameState.ItemSelect:
                break;
            case GameState.Offer:
                break;
            case GameState.CounterOffer:
                break;
            case GameState.Decide:
                HandleDecide();
                break;
            case GameState.ProfitSummary:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(State);
    }

    void HandleDecide() {
        RoundNum++;
        if (RoundNum > ROUND_TOTAL) {
            State = GameState.ProfitSummary;
        }
        else {
            State = GameState.BuyerSelect;
        }
    }

    public void UpdateProfit(int p) {
        profit += p;
    }

    public int GetProfit() {
        return profit;
    }

    public int GetRoundNum() {
        return RoundNum;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.StartScreen);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}

public enum GameState {
    StartScreen,
    BuyerSelect,
    ItemSelect,
    Offer,
    CounterOffer,
    Decide,
    ProfitSummary
}
