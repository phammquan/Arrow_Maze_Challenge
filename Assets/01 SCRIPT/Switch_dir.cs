using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_dir : MonoBehaviour
{
    float dir;
    void Start()
    {
        dir = this.transform.eulerAngles.z;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Player_Controller.Instance.ZRotation != dir)
            {
                Player_Controller.Instance.UpdateDirection(dir);
            }

        }
    }
}
