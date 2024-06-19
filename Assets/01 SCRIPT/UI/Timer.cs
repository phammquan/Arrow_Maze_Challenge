using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remaintime = 0;
    bool checkover = false;

    void Update()
    {
        if (remaintime > 0)
        {
            remaintime -= Time.deltaTime;
        }
        else if (remaintime <= 0)
        {
            remaintime = 0;
            checkover = true;
            GameManager.Instance._Game_Over(checkover);
            timerText.color = Color.red;
        }

        int minutes = Mathf.FloorToInt(remaintime / 60);
        int seconds = Mathf.FloorToInt(remaintime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
