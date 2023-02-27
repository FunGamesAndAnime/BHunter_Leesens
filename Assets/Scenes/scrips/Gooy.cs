using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gooy : MonoBehaviour
{
    public List<GameObject> Itemss;
    // Start is called before the first frame update
    void Start()
    {
        itemCollect.ItemCollected += IncrumentItem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IncrumentItem(ItemS.vegity itemtype)
    {
        cGooy cg = Itemss[(int)itemtype].GetComponent<cGooy>();
        cg.UpdateCount();
    }
}
