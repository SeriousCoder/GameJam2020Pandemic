using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    private Camera mainCamera;
    private NavMeshAgent agent;

    private AIVision vision;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        player = GameObject.FindWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.transform.position);
        Debug.Log(transform.position);

        if (vision.VisionM(player.transform, transform))
        {
            agent.SetDestination(player.transform.position);
        }
    }
}