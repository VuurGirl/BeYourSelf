using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public string levelName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("it colided");
            SceneManager.LoadScene(levelName);
        }
        if (other.CompareTag("Log"))
        {

            this.gameObject.SetActive(false);
        }

    }
}
