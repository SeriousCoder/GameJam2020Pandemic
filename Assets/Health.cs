using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _hp = 100f; //Количество патронов
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController PlayerController = collision.gameObject.GetComponent<PlayerController>();
            PlayerController.GetHeal(_hp);
            Destroy(gameObject);
        }
    }
}
