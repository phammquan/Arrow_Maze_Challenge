using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] Button _Play;
    [SerializeField] Button _Close;
    [SerializeField] GameObject _select_Level;
    [SerializeField] Button[] levelButtons;
    void Start()
    {
        _Play.onClick.AddListener(() =>
        {
            _select_Level.SetActive(true);
        });
        _Close.onClick.AddListener(() =>
        {
            _select_Level.SetActive(false);
        });

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i;
            levelButtons[i].onClick.AddListener(() =>
            {
                SceneManager.LoadScene(levelIndex + 1);
            });
        }
    }
}
