using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMang : MonoBehaviour
{
    public GameObject[] lillypadobj = null;
    
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
            Instantiate(lillypad);
        }
        
    }
}
