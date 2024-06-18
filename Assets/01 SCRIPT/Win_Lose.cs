using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win_Lose : MonoBehaviour
{
    [SerializeField] GameObject _Win;
    [SerializeField] GameObject _Lose;
    [SerializeField] Button _Next;
    [SerializeField] Button _Restart;

    void Start()
    {
        _Next.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            _Win.SetActive(false);
        });
        _Restart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _Lose.SetActive(false);
        });
    }
    void Update()
    {
        Check();

    }

    void Check()
    {
        if (GameManager.Instance._Finish)
        {
            _Win.SetActive(true);
        }
        if (GameManager.Instance.Game_Over)
        {
            _Lose.SetActive(true);
        }
    }
}
