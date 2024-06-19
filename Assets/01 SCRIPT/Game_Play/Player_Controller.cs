using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player_Controller : Singleton<Player_Controller>
{
    [SerializeField] float _speed;
    Rigidbody2D _rigi;
    Collider2D _coli;
    Vector2 _direction;
    [SerializeField] float checkchil;
    [SerializeField] bool _isMoving = false;
    float _update_dir;
    float zRotation;
    public float ZRotation => zRotation;
    bool _isTouch = false;





    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _coli = GetComponent<Collider2D>();
    }

    void Update()
    {
        checkTouch();
        checkDirection();
        if (_isMoving)
        {
            move();
        }
    }

    void move()
    {
        _rigi.velocity = _direction * _speed * Time.deltaTime;

    }
    void checkDirection()
    {
        zRotation = this.transform.GetChild(0).transform.eulerAngles.z;

        if (zRotation == 90)
        {
            _direction = Vector2.down;
        }
        else if (zRotation == 270)
        {
            _direction = Vector2.up;
        }
        else if (zRotation == 0)
        {
            _direction = Vector2.left;
        }
        else if (zRotation == 180)
        {
            _direction = Vector2.right;
        }

    }
    void checkTouch()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
            if (touch.phase == TouchPhase.Began && hit.collider == _coli)
            {
                _isMoving = true;
            }

        }
    }
    public void UpdateDirection(float dir)
    {
        _update_dir = dir;
    }
    public void SetTouch(bool touch)
    {
        _isTouch = touch;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_isTouch && other.gameObject.CompareTag("Trap") || other.gameObject.CompareTag("Platform"))
        {
            _isMoving = false;
            this.transform.GetChild(0).transform.eulerAngles = new Vector3(0, 0, _update_dir);
        }
    }


}
