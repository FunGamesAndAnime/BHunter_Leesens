using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine.Networking;

public class playerMovement : Mirror.NetworkBehaviour
{
    private Rigidbody rbplayer;
    private Vector3 diretion = Vector3.zero;
    public float speed = 10.0f;
    public GameObject[] spawnPoints = null;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        rbplayer = GetComponent<Rigidbody>();
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
       
        

    }
    
    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float hermove = Input.GetAxis("Horizontal");
        float vermove = Input.GetAxis("Vertical");
        diretion = new Vector3(hermove, 0, vermove);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
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
        int index = 0;
        while (Physics.CheckBox(spawnPoints[index].transform.position, new Vector3(1.5f, 1.5f, 1.5f)))
        {
            index++;
        }

        rbplayer.MovePosition(spawnPoints[index].transform.position);
    }
    
   
    private void OnTriggerExit(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (other.CompareTag("Hazard"))
        {
            Respawn();
        }

    }

}
