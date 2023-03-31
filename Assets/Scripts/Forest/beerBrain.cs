using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beerBrain : MonoBehaviour
{
    private Bot bot;
    // Start is called before the first frame update
    void Start()
    {
        bot = GetComponent<Bot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bot.CanTargetSeeMe())
        {
            bot.Evade();
        }
        else if(bot.CanSeeTarget())
        {
            bot.Pursue();
        }
        else
        {
            bot.Wander();
        }
    }
}
