﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIScript : MonoBehaviour
{
    private Camera mainCamera;
    private NavMeshAgent agent;

    private AIVision vision;
    private GameObject player;


    [SerializeField] private float speed;
    [SerializeField] private Transform[] moveSpots;
    [SerializeField] private int randomSpot;

    [SerializeField] private float defWaitTime = 5.0f;
    [SerializeField] private float waitTime;
    
    [SerializeField] private float defChaseTime = 5.0f;
    private float chaseTime;
    [SerializeField] private BotState state;
    private Vector3 lastPlayerPos;

    enum BotState
    {
        Idle,
        Patrol,
        Chase,
        Alarm
    }

    void Start()
    {
        mainCamera = Camera.main;

        player = GameObject.FindWithTag("Player");

        vision = new AIVision();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        randomSpot = Random.Range(0, moveSpots.Length);
        state = BotState.Idle;
    }

    void Update()
    {
        switch (state)
        {
            case BotState.Idle:
                state = BotState.Patrol;
                randomSpot = Random.Range(0, moveSpots.Length);
                SetDestinationToPoint(moveSpots[randomSpot]);
                waitTime = defWaitTime;
                break;
            case BotState.Patrol:
                //Debug.Log(Vector2.Distance(moveSpots[randomSpot].position, transform.position));
                if (Vector2.Distance(moveSpots[randomSpot].position, transform.position) < 0.1f)
                {
                    if (waitTime <= 0)
                    {
                        randomSpot = Random.Range(0, moveSpots.Length);
                        SetDestinationToPoint(moveSpots[randomSpot]);
                        waitTime = defWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
                SetDestinationToPoint(moveSpots[randomSpot]);

                break;
            case BotState.Alarm:
                //Debug.Log(Vector2.Distance(lastPlayerPos, transform.position));
                if (Vector2.Distance(lastPlayerPos, transform.position) < 0.1f)
                {
                    state = BotState.Chase;
                    chaseTime = defChaseTime;
                }
                break;
            case BotState.Chase:
                if (chaseTime > 0.0)
                {
                    chaseTime -= Time.deltaTime;
                }
                else
                {
                    state = BotState.Idle;
                }
                break;
        }

        if (vision.VisionM(player.transform, transform))
        {
            Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            transform.up = direction;
            agent.SetDestination(player.transform.position);

            lastPlayerPos = player.transform.position;
            state = BotState.Alarm;

            SetDestinationToPoint(player.transform);
        }

        //for (int i = 0; i < agent.path.corners.Length - 1; i++)
        //{
        //    Debug.DrawLine(agent.path.corners[i], agent.path.corners[i + 1], Color.red);
        //}
        if (agent.path.corners.Length > 1) LookAtPoint(agent.path.corners[1]);

        DrawVisionRadius();
    }

    private void SetDestinationToPoint(Transform target)
    {
        Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = direction;
        agent.SetDestination(target.position);
    }

    private void LookAtPoint(Vector3 point)
    {
        Vector2 direction = new Vector2(point.x - transform.position.x, point.y - transform.position.y);
        transform.up = direction;
    }

    private void DrawVisionRadius()
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