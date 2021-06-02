using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
	public GameObject player;
	NavMeshAgent agent;
	public GameObject spawn;
  // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward *2f, Color.red);
    	float dist = Vector3.Distance(player.transform.position, transform.position);
    	print(dist);
    	if(dist <=10f)
    	{
    		agent.SetDestination(player.transform.position);
    	}
    	
    }

    

    
    	

}
