using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Скорость снаряда
    [SerializeField] private float _speed = 15;
    //Время жизни снаряда
    [SerializeField] private float _lifeTime = 2;
    //Урон снаряда
    [SerializeField] private int _damage = 5;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Shot");
        Destroy(gameObject, _lifeTime);
    }

    void Update()
    {
        //Перемещаем пулю
        transform.position += CalculateSpeed(_speed);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    private Vector3 CalculateSpeed(float dir)
    {
        //Возвращаем вектор движения снаряда
        return transform.up * dir * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Если объект пересечения имеет тег "Враг", то наносим ему урон
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Получаем скрипт врага, вызываем функцию "GetDamage"
            //var enemy = collision.gameObject.GetComponent<EnemyScript>();
            //enemy.GetDamage(_damage);

            //Уничтожаем снаряд, чтобы он не летел дальше
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            //Получаем скрипт врага, вызываем функцию "GetDamage"
            var enemy = collision.gameObject.GetComponent<PlayerController>();
            enemy.GetDamage(_damage);

            //Уничтожаем снаряд, чтобы он не летел дальше
            Destroy(gameObject);
        } //Иначе если это "Земля" или "Стена", то уничтожаем объект
        else if (collision.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
