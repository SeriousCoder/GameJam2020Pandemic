using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _cdDamage = 0.8f;
    private float _currentCdDamage;
    private Animation _animation;
    // Start is called before the first frame update
    void Start()
    {
        _animation = GetComponent <Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        Atack();
        _currentCdDamage += Time.deltaTime;
    }

    public void Atack()
    {
        _animation.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_currentCdDamage < _cdDamage) return;
            //Получаем скрипт врага, вызываем функцию "GetDamage"
            var enemy = collision.gameObject.GetComponent<PlayerController>();
            enemy.GetDamage(_damage);
            _currentCdDamage = 0f;
        }
    }

}
