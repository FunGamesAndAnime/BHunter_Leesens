using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rbplayer;
    private Vector3 diretion = Vector3.zero;
    public float speed = 10.0f;
    public GameObject spawnPiont = null;
    private Dictionary<Item.vegity, int> itemin = new Dictionary<Item.vegity, int>();
    // Start is called before the first frame update
    void Start()
    {
        rbplayer = GetComponent<Rigidbody>();
        foreach(Item.vegity item in System.Enum.GetValues(typeof(Item.vegity)))
        {
            itemin.Add(item, 0);
        }
        

    }
    private void addtoinventory(Item item)
    {
        itemin[item.typeofvegi]++;
    }
    private void printIN()
    {
        string output = "";
        foreach(KeyValuePair<Item.vegity, int> kvp in itemin)
        {
            output += string.Format("{0}: {1} ", kvp.Key, kvp.Value);
        }
        Debug.Log(output);
    }
    private void Update()
    {
        float hermove = Input.GetAxis("Horizontal");
        float vermove = Input.GetAxis("Vertical");
        diretion = new Vector3(hermove, 0, vermove);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbplayer.AddForce(diretion * speed, ForceMode.Force);

        if(transform.position.z > 40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 40);
        }
        else if(transform.position.z < -40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        }
        
    }
    private void Respawn()
    {
        rbplayer.MovePosition(spawnPiont.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item item = other.gameObject.GetComponent<Item>();
            addtoinventory(item);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            Respawn();
        }

    }

}
