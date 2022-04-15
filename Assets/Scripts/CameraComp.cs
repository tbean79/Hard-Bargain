using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComp : MonoBehaviour
{
    [SerializeField]
    public Camera CameraObj;

    public GameObject SelectBuyerFocusPoint;
    public GameObject SelectItemFocusPoint;
    public GameObject HaggleFocusPoint;
    public GameObject CounterFocusPoint;

    public GameObject StartPlacementPoint;
    public GameObject SelectBuyerPlacementPoint;
    public GameObject SelectItemPlacementPoint;
    public GameObject HagglePlacementPoint;

    public GameObject BuyerSelector;

    public float speed = 45f;

    private Transform m_Target;
    private Vector3 m_Pos;


    void Awake() {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    void GameManagerOnGameStateChanged(GameState state) {
        // use switch/case to be at/look at different ref points on map?  Is there better way?
        switch (state)
        {
            case GameState.BuyerSelect:
                m_Target = SelectBuyerFocusPoint.transform;
                m_Pos = SelectBuyerPlacementPoint.transform.position;
                break;

            case GameState.ItemSelect:
                m_Target = SelectItemFocusPoint.transform;
                m_Pos = SelectItemPlacementPoint.transform.position;
                break;

            case GameState.Offer:
                m_Target = HaggleFocusPoint.transform;
                m_Pos = HagglePlacementPoint.transform.position;
                break;
            case GameState.CounterOffer:
                m_Target = CounterFocusPoint.transform;
                break;
            default:
                break;
                //throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Target = HaggleFocusPoint.transform;
        m_Pos = StartPlacementPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lTargetDir = m_Target.position - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.deltaTime * speed * 10);
        transform.position = Vector3.MoveTowards(transform.position, m_Pos, Time.deltaTime * speed);
    }
}
