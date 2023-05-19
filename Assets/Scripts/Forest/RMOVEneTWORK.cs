using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine.Networking;

public class RMOVEneTWORK : Mirror.NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject netmgr = GameObject.Find("networkmanagor");
        Mirror.NetworkManagerHUD netMgrHUD = netmgr.GetComponent<Mirror.NetworkManagerHUD>();
        netMgrHUD.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
