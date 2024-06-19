using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_dir : MonoBehaviour
{
    float dir;
    bool isTouch = false;
    void Start()
    {
        dir = this.transform.GetChild(0).transform.eulerAngles.z;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Player_Controller.Instance.ZRotation != dir)
            {
                isTouch = true;
                Player_Controller.Instance.UpdateDirection(dir);
                Player_Controller.Instance.SetTouch(isTouch);
            }

        }
    }
}
