using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selector : MonoBehaviour
{
    [SerializeField]
    public GameObject SelecterObj;

    [SerializeField]
    public BuyerManager buyerManager;

    protected List<MonoBehaviour> iterObjs;
    protected int currentIndex;
    protected float YOffset;

    protected virtual void Awake() {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    protected virtual void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    protected abstract void GameManagerOnGameStateChanged(GameState state);

    public MonoBehaviour GetSelectedObject() {
        return iterObjs[currentIndex];
    }

    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentIndex = 0;
        // var currentObj = iterObjs[currentIndex];
        InitSelector();
    }

    protected void InitSelector() {
        transform.position = new Vector3(iterObjs[currentIndex].transform.position.x, 
            iterObjs[currentIndex].transform.position.y + YOffset, iterObjs[currentIndex].transform.position.z);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.anyKeyDown) {
            var dir = Input.GetAxisRaw("Horizontal");
            currentIndex = (int)(iterObjs.Count + currentIndex + dir) % iterObjs.Count;
            var currentObj = iterObjs[currentIndex];
            //transform.parent = currentObj.transform;
            transform.position = new Vector3(currentObj.transform.position.x, currentObj.transform.position.y + YOffset, currentObj.transform.position.z);
        }
    }
}
