using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _barrel;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _cooldown = 0.3f;
    private float _currentCooldown;

    void Start()
    {
        
    }

    void Update()
    {
        //Fire();
        if (_currentCooldown <= _cooldown)
            _currentCooldown += Time.deltaTime;
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
