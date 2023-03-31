using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swormbrain : MonoBehaviour
{
    private bool hashive = true;
    private Patrol patrol;
    private Bot bot;
    // Start is called before the first frame update
    void Start()
    {
        patrol = GetComponent<Patrol>();
        bot = GetComponent<Bot>();
        HivePickUp.HivePickedUp += hivetaken;
    }
    void hivetaken()
    {
        hashive = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (hashive)
        {
            patrol.PatrolWaypoints();
        }
        else
        {
            bot.Pursue();
        }
    }
}

internal class Patrol
{
    internal void PatrolWaypoints()
    {
        throw new NotImplementedException();
    }
}