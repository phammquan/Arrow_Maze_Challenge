using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Touch : MonoBehaviour
{
    Collider2D _coli;
    public bool _isTouch = false;
    [SerializeField] LayerMask _layerMask;
    void Start()
    {
        _coli = GetComponent<Collider2D>();
    }

    void Update()
    {
        checkTouch();
    }
    void checkTouch()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, _layerMask);
            if (touch.phase == TouchPhase.Began && hit.collider == _coli)
            {
                _isTouch = true;
            }

        }
    }
}
