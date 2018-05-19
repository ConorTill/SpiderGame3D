using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationComponent : MonoBehaviour {

    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		
	}

    public void setDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
        continueNavigating();
    }

    public void stopNavigating()
    {
        if (!agent.isStopped)
            agent.isStopped = true;
    }

    public void continueNavigating()
    {
        if (agent.isStopped)
            agent.isStopped = false;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
