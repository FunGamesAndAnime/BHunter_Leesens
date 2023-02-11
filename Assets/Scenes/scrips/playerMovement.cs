using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody rbplayer;
    private Vector3 diretion = Vector3.zero;
    public float speed = 10.0f;
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
        
    }
}
