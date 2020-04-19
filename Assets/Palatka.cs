using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palatka : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController PlayerController = collision.gameObject.GetComponent<PlayerController>();
            PlayerController.transform.position = transform.position;
            PlayerController.getBombed = true;
            PlayerController.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
