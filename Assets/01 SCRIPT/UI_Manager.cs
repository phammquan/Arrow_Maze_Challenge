using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    [SerializeField] Button _btn_Restart;
    [SerializeField] Button _btn_Home;
    void Start()
    {
        _btn_Restart.onClick.AddListener(() => Restart());


    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
