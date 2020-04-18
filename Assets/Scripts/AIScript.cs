using System;
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

    void Start()
    {
        mainCamera = Camera.main;

        player = GameObject.FindWithTag("Player");

        vision = new AIVision();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (vision.VisionM(player.transform, transform))
        {
            Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            transform.up = direction;
            agent.SetDestination(player.transform.position);
        }

        DrawRadiusObzora();
    }

    private void DrawRadiusObzora()
    {
        float j = 0;
        int rays = 6;
        float angle = vision.ActiveAng;
        float distance = vision.ActiveDis;
        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, y, 0));
            Debug.DrawRay(transform.position, dir * distance, Color.red);
            dir = transform.TransformDirection(new Vector3(-x, y, 0));
            Debug.DrawRay(transform.position, dir * distance, Color.red);

        }
    }
}