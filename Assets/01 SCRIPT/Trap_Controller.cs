using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Controller : MonoBehaviour
{
    Collider2D _coli;
    bool _isMoving = false;
    [SerializeField] GameObject _prefab;
    [SerializeField] List<GameObject> _listPrefabs = new List<GameObject>();
    void Start()
    {
        _coli = GetComponent<Collider2D>();
    }

    void Update()
    {
        checkTouch();
        tunrOnDir();
        ShootRays();
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
            else if (touch.phase == TouchPhase.Began)
            {
                _isMoving = false;
            }

        }
    }
    void tunrOnDir()
    {
        if (_isMoving)
        {
            for (int i = 0; i < _listPrefabs.Count; i++)
            {
                _listPrefabs[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _listPrefabs.Count; i++)
            {
                _listPrefabs[i].SetActive(false);
            }
        }
    }

    void ShootRays()
    {
        Vector2[] directions = new Vector2[]
        {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
        };

        RaycastHit2D[] hits = new RaycastHit2D[4];

        for (int i = 0; i < directions.Length; i++)
        {
            int hitCount = _coli.Cast(directions[i], hits, 0.5f);
            if (hitCount > 0 && hits[0].collider.CompareTag("Platform"))
            {
                // Deactivate the corresponding prefab from the list
                if (_listPrefabs[i].activeSelf)
                {
                    _listPrefabs[i].SetActive(false);
                }
            }
        }
    }


}
