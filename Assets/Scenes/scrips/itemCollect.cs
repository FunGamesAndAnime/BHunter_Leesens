using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Networking;
public class itemCollect : Mirror.NetworkBehaviour

{
    public delegate void CollectItem(ItemS.vegity item);
    public static event CollectItem ItemCollected;
    Collider itemCollecter = null;

    private Dictionary<ItemS.vegity, int> itemin = new Dictionary<ItemS.vegity, int>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (ItemS.vegity item in System.Enum.GetValues(typeof(ItemS.vegity)))
        {
            itemin.Add(item, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (itemCollecter && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("sp item");
            ItemS item = itemCollecter.gameObject.GetComponent<ItemS>();
            addtoinventory(item);
            ItemCollected.Invoke(item.typeofvegi);
            printIN();
        }
    }

        private void OnTriggerEnter(Collider other)
        {
          if (!isLocalPlayer)
          {
            return;
          }

           if (other.CompareTag("Item")) 
           {
            itemCollecter = other;


            

           }
        }
    private void OnTriggerExit(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (other.CompareTag("Item") && Input.GetKeyDown(KeyCode.Space))
        {
            itemCollecter = null;
        }
    }
    private void addtoinventory(ItemS item)
    {
        itemin[item.typeofvegi]++;
    }
    private void printIN()
    {
        string output = "";
        foreach (KeyValuePair<ItemS.vegity, int> kvp in itemin)
        {
            output += string.Format("{0}: {1} ", kvp.Key, kvp.Value);
        }
        Debug.Log(output);
    }
}
