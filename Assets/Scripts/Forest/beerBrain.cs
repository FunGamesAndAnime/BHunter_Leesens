using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beerBrain : MonoBehaviour
{
    private Bot bot;
    private Vector3 hivepos;
    private bool hivedropped = false;
    private bool isStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        bot = GetComponent<Bot>();
        NavPlayerMovement.DroppedHive += HiveReady;
    }
    public void HiveReady(Vector3 pos)
    {
        hivepos = pos;
        hivedropped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
        {
            if (hivedropped)
            {
                bot.Seek(hivepos);
            }
            else
            {


                if (bot.CanTargetSeeMe())
                {
                    bot.Evade();
                }
                else if (bot.CanSeeTarget())
                {
                    bot.Pursue();
                }
                else
                {
                    bot.Wander();
                }
            }
        }
       

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            bot.Stop();
            isStopped = true;
        }
    }
}
