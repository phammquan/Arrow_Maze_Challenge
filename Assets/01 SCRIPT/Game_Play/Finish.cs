using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    bool _finish = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _finish = true;
            StartCoroutine(FinishLevel());
        }
    }
    IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Finish(_finish);

    }
}
