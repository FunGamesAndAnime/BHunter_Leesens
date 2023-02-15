using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rbplayer;
    private Vector3 diretion = Vector3.zero;
    public float speed = 10.0f;
    public GameObject spawnPiont = null;
    // Start is called before the first frame update
    void Start()
    {
        rbplayer = GetComponent<Rigidbody>();

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
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            Respawn();
        }
    }
}
