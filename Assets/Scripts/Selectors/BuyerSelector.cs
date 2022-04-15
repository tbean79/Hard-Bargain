using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerSelector : Selector
{

    public GameObject BuyerOnePoint;
    public GameObject BuyerTwoPoint;

    private MonoBehaviour OldManBuyer;
    private MonoBehaviour BoyBuyer;
    private MonoBehaviour WomanBuyer;
    private MonoBehaviour PreacherBuyer;
    private MonoBehaviour EldritchBuyer;
    private MonoBehaviour BigManBuyer;

    protected override void GameManagerOnGameStateChanged(GameState state) {
        SelecterObj.SetActive(state == GameState.BuyerSelect);
        if (state == GameState.BuyerSelect) {
            switch (GameManager.Instance.GetRoundNum()) {

                case 2:
                    iterObjs = new List<MonoBehaviour>(new MonoBehaviour[] 
                        {WomanBuyer, PreacherBuyer});
                    break;
                case 3:
                    iterObjs = new List<MonoBehaviour>(new MonoBehaviour[] 
                        {BigManBuyer, EldritchBuyer});
                    break;
                default:
                    break;
            }
            // set iterobjs active, all others inactive
            SetOnlyIterObjActive();
            // and put in correct spot
            SetPasserbys();
            InitSelector();
        }

    }

    private void SetPasserbys() {
        iterObjs[0].transform.position = BuyerOnePoint.transform.position;
        iterObjs[1].transform.position = BuyerTwoPoint.transform.position;
    }

    public void SetOnlyIterObjActive() {
        var objs = Resources.FindObjectsOfTypeAll(typeof(Buyer));
        foreach (MonoBehaviour obj in objs) {
            obj.gameObject.SetActive(iterObjs.Contains(obj));
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        YOffset = 4;
        OldManBuyer = FindObjectsOfType<OldManBuyer>()[0];
        BoyBuyer = FindObjectsOfType<BoyBuyer>()[0];
        WomanBuyer = FindObjectsOfType<WomanBuyer>()[0];
        PreacherBuyer = FindObjectsOfType<PreacherBuyer>()[0];
        EldritchBuyer = FindObjectsOfType<EldritchBuyer>()[0];
        BigManBuyer = FindObjectsOfType<BigManBuyer>()[0];

        iterObjs = new List<MonoBehaviour>(new MonoBehaviour[] 
            {OldManBuyer, BoyBuyer});
        SetPasserbys();
        base.Start();
    }

    //GameManager.Instance.UpdateGameState(new state) when wanting to create new state
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Return)) {
            buyerManager.OnBuyerSelect((Buyer)iterObjs[currentIndex]);
            GameManager.Instance.UpdateGameState(GameState.ItemSelect);
        }
    }
}
