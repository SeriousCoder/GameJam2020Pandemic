using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadzone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController PlayerController = collision.gameObject.GetComponent<PlayerController>();
            //PlayerController.StartAnimation(); //Стартовать анимацию оглушения
            transform.parent.GetComponent<AIScript>().getConfused = true;
            FindObjectOfType<AudioManager>().Play("Strike");
        }
    }
}
