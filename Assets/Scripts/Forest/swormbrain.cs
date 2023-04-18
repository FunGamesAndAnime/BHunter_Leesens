using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swormbrain : MonoBehaviour
{
    private bool hashive = true;
    private potroling patrol;
    private Bot bot;
    // Start is called before the first frame update
    void Start()
    {
        patrol = GetComponent<potroling>();
        bot = GetComponent<Bot>();
        HivePickUp.HivePickedUp += Hivetaken;
    }
    void Hivetaken()
    {
        hashive = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (hashive)
        {
            patrol.potralWP();
        }
        else
        {
            bot.Pursue();
        }
    }
}


