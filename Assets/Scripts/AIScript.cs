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

    enum BotState
    {
        idle
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        player = GameObject.FindWithTag("Player");

        vision = new AIVision();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.transform.position);
        //Debug.Log(transform.position);
        //Debug.Log(vision);

        if (vision.VisionM(player.transform, transform))
        {
            //transform.LookAt(player.transform);

            Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            transform.up = direction;

            //transform.Rotate(new Vector3(0, 0, ((player.transform.position - transform.position)/2).z));

            //Debug.Log(transform.up);
            //Debug.DrawLine(transform.position, transform.up);
            agent.SetDestination(player.transform.position);
        }
    }
}