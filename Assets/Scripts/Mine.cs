using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    [SerializeField] private float _damage = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().Play("Explosion");
        Boom();
    }

    private void Boom()
    {
        float explosionRadius = 3;// радиус поражения
        float power = 1400;// сила взрыва	
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Rigidbody2D[] physicObject;// тут будут все физ. объекты которые есть на сцене

        physicObject = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];// Записываем все физ. объекты
        for (int i = 0; i < physicObject.Length; i++)
        {
            if (Vector3.Distance(transform.position, physicObject[i].transform.position) <= explosionRadius)
            {
                AddExplosive(physicObject[i], power, transform.position, explosionRadius);

            }
        }
        Destroy(this.gameObject);
    }

    void AddExplosive(Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
    {
        var explosionDir = rb.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;
        if(rb.CompareTag("Player"))
        {
            PlayerController Player = rb.GetComponent<PlayerController>();
            Player.getConfused = true;
            Player.GetDamage(_damage);
        }
        if (rb.CompareTag("Enemy"))
        {
            AIScript Player = rb.GetComponent<AIScript>();
            Player.GetDamage(_damage);
        }
            rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
    }
}
