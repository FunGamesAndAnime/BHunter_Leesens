using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class spawnMang : Mirror.NetworkBehaviour
{
    public GameObject[] lillypadobj = null;
    public override void OnStartServer()
    {
        InvokeRepeating("SpawnLilyPad", 2.0f, 5.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SPlillypad", 2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SPlillypad()
    {
        foreach(GameObject lillypad in lillypadobj)
        {
            GameObject tempLilyPad = Instantiate(lillypad);
            Mirror.NetworkServer.Spawn(tempLilyPad);
        }
        
    }
}
