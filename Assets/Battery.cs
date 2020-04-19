﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] private float _charge = 100f; //Количество патронов
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController PlayerController = collision.gameObject.GetComponent<PlayerController>();
            PlayerController.GetCharge(_charge);
            Destroy(gameObject);
        }
    }
}
