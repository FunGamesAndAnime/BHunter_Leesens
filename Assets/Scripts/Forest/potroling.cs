using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class potroling : MonoBehaviour
    
{
    private const float WP_threshold = 3.0f;
    public List<GameObject> waypoints;
    private NavMeshAgent agent;
    private GameObject currentWP;
    private int currentWPindex = -1;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWP = getnextWP();
    }
    GameObject getnextWP()
    {
            currentWPindex++;
        if (currentWPindex == waypoints.Count)
        {
            currentWPindex = 0;
        }

        return waypoints[currentWPindex];
    }

    // Update is called once per frame
    public void potralWP()
    {
        if(Vector3.Distance(transform.position, currentWP.transform.position)<WP_threshold)
        {
            currentWP = getnextWP();
            agent.SetDestination(currentWP.transform.position);
        }
        
        
    }
}
