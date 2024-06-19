using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    [SerializeField] Button _btn_Restart;
    [SerializeField] Button _btn_Home;
    [SerializeField] Button TUT;
    [SerializeField] Button Close;
    [SerializeField] GameObject _TUT;
    void Start()
    {
        _btn_Restart.onClick.AddListener(() => Restart());
        _btn_Home.onClick.AddListener(() => Home());
        TUT.onClick.AddListener(() => _TUT.SetActive(true));
        Close.onClick.AddListener(() => _TUT.SetActive(false));

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Home()
    {
        SceneManager.LoadScene(0);
    }
}
