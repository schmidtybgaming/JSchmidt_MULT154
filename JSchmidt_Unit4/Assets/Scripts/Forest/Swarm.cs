using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Swarm : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> waypoints;
    [SerializeField]
    private int waypointIndex;
    private float WAYPOINT_THRESHOLD = 1.0f;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        agent.SetDestination(waypoints[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < WAYPOINT_THRESHOLD)
        {
            waypointIndex++;
            
            if (waypointIndex == waypoints.Count)
            {
                waypointIndex = 0;
            }

            agent.SetDestination(waypoints[waypointIndex].transform.position);
        }
    }
}
