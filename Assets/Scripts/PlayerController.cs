using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    private float _currentHP;
    [SerializeField] private float _maxHP = 100;
    private float _currentCharge;
    [SerializeField] private float _maxCharge = 100;
    private Rigidbody2D _rb;
    private Transform _sprite;

    void Start()
    {
        _currentHP = _maxHP;
        _currentCharge = _maxCharge;
        _rb = GetComponent<Rigidbody2D>();
        _sprite = transform.Find("Sprite");
    }

    void Update()
    {
        //moving
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        _rb.velocity = new Vector2(MoveX * _speed, MoveY * _speed);

        //rotate
        if(MoveX*MoveX > MoveY* MoveY)
        {
            //if (MoveX > 0) _sprite.rotation = new Quaternion(0, 0, -90, 90);
            //else if (MoveX < 0) _sprite.rotation = new Quaternion(0, 0, 90, 90);
        }
        else
        {
            //if (MoveY > 0) _sprite.rotation = new Quaternion(0, 0, 0, 0);
            //else if (MoveY < 0) _sprite.rotation = new Quaternion(0, 0, 180, 0);
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    //RaycastHit2D raycast2d = Physics2D.Raycast(new Vector2(Input.mousePosition.x, Input.mousePosition.y), Vector2.up*500);
        //    //Debug.Log(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        //    //Debug.Log(raycast2d.collider);

        //    Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector2 point2d = new Vector2(point.x, point.y);
        //    RaycastHit2D raycast2d = Physics2D.Raycast(point2d, point2d);
        //    Debug.Log(raycast2d.collider);
        //}

        //battery
        _currentCharge -= Time.deltaTime;
    }
    
    public float GetCurrentHP()
    {
        return _currentHP;
    }

    public float GetCurrentCharge()
    {
        return _currentCharge;
    }
    
    public void GetDamage(float damage)
    {
        _currentHP -= damage;
    }

    public void GetCharge(float charge)
    {
        _currentCharge -= charge;
    }

    public void GetHeal(float hp)
    {
        _currentHP -= hp;
    }
}
