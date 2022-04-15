using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : Selector
{

    public GameObject ItemOnePoint;
    public GameObject ItemTwoPoint;
    public GameObject ItemThreePoint;

    private MonoBehaviour CharmBraceletItem;
    private MonoBehaviour BlanketItem;
    private MonoBehaviour WoodenSwordItem;
    private MonoBehaviour SupremeTeeItem;
    private MonoBehaviour UnicornItem;

    protected override void GameManagerOnGameStateChanged(GameState state) {
        SelecterObj.SetActive(state == GameState.ItemSelect);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        YOffset = 2;
        CharmBraceletItem = FindObjectsOfType<CharmBraceletItem>()[0];
        BlanketItem = FindObjectsOfType<BlanketItem>()[0];
        WoodenSwordItem = FindObjectsOfType<WoodenSwordItem>()[0];
        SupremeTeeItem = FindObjectsOfType<SupremeTeeItem>()[0];
        UnicornItem = FindObjectsOfType<UnicornItem>()[0];

        iterObjs = new List<MonoBehaviour>(new MonoBehaviour[] 
                    {CharmBraceletItem, BlanketItem, WoodenSwordItem});
        SetStore();
        base.Start();
    }

    private void SetStore() {
        if (iterObjs.Count >= 3) {
            iterObjs[0].transform.position = new Vector3(
                ItemOnePoint.transform.position.x, ItemOnePoint.transform.position.y + 1, ItemOnePoint.transform.position.z);
            iterObjs[1].transform.position = new Vector3(
                ItemTwoPoint.transform.position.x, ItemTwoPoint.transform.position.y + 1, ItemTwoPoint.transform.position.z);
            iterObjs[2].transform.position = new Vector3(
                ItemThreePoint.transform.position.x, ItemThreePoint.transform.position.y + 1, ItemThreePoint.transform.position.z);
        }
    }

    public void SetOnlyIterObjActive() {
        var objs = Resources.FindObjectsOfTypeAll(typeof (Item));
        foreach (MonoBehaviour obj in objs) {
            obj.gameObject.SetActive(iterObjs.Contains(obj));
        }
    }

    public void RemoveObjFromIterObjs(MonoBehaviour obj) {
        iterObjs.Remove(obj);
        AddToIterObjs();
    }

    private void AddToIterObjs() {
        switch (GameManager.Instance.GetRoundNum()) {
                case 1:
                    iterObjs.Add(SupremeTeeItem);
                    break;
                case 2:
                    iterObjs.Add(UnicornItem);
                    break;
                default:
                    break;
        }
        // set iterobjs active, all others inactive
        SetOnlyIterObjActive();
        // and put in correct spot
        SetStore();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Return)) {
            buyerManager.OnItemSelect((Item)iterObjs[currentIndex]);
            GameManager.Instance.UpdateGameState(GameState.Offer);
        }
    }
}
