using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class Dzot : MonoBehaviour
{
    [SerializeField] private Transform _barrel;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _cooldown = 0.7f;
    private float _currentCooldown;
    private GameObject player;
    private Camera mainCamera;
    private AIVision vision;
    [SerializeField] private float ActiveDis = 6;
    [SerializeField] private DzotState state;
    [SerializeField] private float rotationSpeed = 0.5f;
    private Vector3 initPos;
    private Quaternion initRot;
    Vector2 initUp;

    enum DzotState
    {
        Idle,
        Alarm
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mainCamera = Camera.main;
        vision = new AIVision();
        vision.ActiveAng = 90;
        vision.ActiveAng2 = 180;
        vision.ActiveDis = ActiveDis;
        vision.ActiveRad = 1;        
        state = DzotState.Idle;
        initPos = transform.position;
        initRot = transform.rotation;
        initUp = transform.up;
    }

    void Update()
    {
        if (_currentCooldown <= _cooldown)
            _currentCooldown += Time.deltaTime;

        switch (state)
        {
            case DzotState.Idle:
                transform.up = Vector3.Lerp(transform.up, initUp, Time.deltaTime * rotationSpeed);
                break;
            case DzotState.Alarm:
                Fire();
                //transform.rotation = Quaternion.Lerp(transform.rotation, initRot, Time.deltaTime * rotationSpeed);
                Vector2 direction = new Vector2(player.transform.position.x - transform.position.x,
                player.transform.position.y - transform.position.y);
                transform.up = Vector3.Lerp(transform.up, direction, Time.deltaTime * rotationSpeed);
                break;
        }

        if (vision.VisionM(player.transform, _barrel))
            state = DzotState.Alarm;
        else
            state = DzotState.Idle;
    }

    public void Fire()
    {
        if (_currentCooldown > _cooldown)
        {
            Instantiate(_bullet, _barrel);
            _currentCooldown = 0;
        }
    }
}
