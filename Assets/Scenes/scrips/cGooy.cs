using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cGooy : MonoBehaviour
{
    private TextMeshProUGUI tmProElem;
    public string itemname;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        tmProElem = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateCount()
    {
        count++;
        tmProElem.text = itemname + ": " + count;
    }
}
