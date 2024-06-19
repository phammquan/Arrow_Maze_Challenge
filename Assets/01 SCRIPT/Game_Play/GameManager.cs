using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    [SerializeField] List<GameObject> _list_trap = new List<GameObject>();
    bool moved = false;
    bool _finish = false;
    bool _game_over = false;
    public bool _Finish => _finish;
    public bool Game_Over => _game_over;


    void Update()
    {
        if (moved == true && Trap_Controller.Instance.Moved == true)
        {
            moved = false;
        }
        if (!moved)
        {
            Check_Move();
        }
    }
    void Check_Move()
    {
        foreach (GameObject trap in _list_trap)
        {
            if (trap.GetComponent<Check_Touch>()._isTouch)
            {
                for (int i = 0; i < _list_trap.Count; i++)
                {
                    if (_list_trap[i] == trap)
                    {
                        trap.GetComponent<Check_Touch>()._isTouch = false;
                        Trap_Controller.Instance.move(i);
                        moved = true;
                    }
                }
            }
        }
    }
    public void Finish(bool finish)
    {
        if (finish)
        {
            _finish = true;
            Debug.Log("Finish");

        }
    }
    public void _Game_Over(bool over)
    {
        if (over)
        {
            _game_over = true;
        }
        Debug.Log("Game Over");
    }
    IEnumerator eFinish()
    {
        yield return new WaitForSeconds(2f);
    }
}
