using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryTransform : MonoBehaviour
{
    public GameObject bunny;
    public GameObject bear;
    public GameObject fox;

  
    void Start()
    {
        bunny.SetActive(false);
        bear.SetActive(false);
        fox.SetActive(true);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
         
        if (other.CompareTag("Player") && this.CompareTag("cherry"))
        {
            fox.SetActive(false);
            bunny.SetActive(false);
            bear.SetActive(true);
            ScoreManager.Instance.AnimalCount =  2;
            this.gameObject.SetActive(false);
        }
        if (other.CompareTag("Player") && this.CompareTag("Gem"))
        {
            fox.SetActive(true);
            bunny.SetActive(false);
            bear.SetActive(false);
            ScoreManager.Instance.AnimalCount  = 3;
            this.gameObject.SetActive(false);
        }
        if (other.CompareTag("Player") && this.CompareTag("carrot"))
        {
            fox.SetActive(false);
            bunny.SetActive(true);
            bear.SetActive(false);
            ScoreManager.Instance.AnimalCount = 1;
            this.gameObject.SetActive(false);
        }
 
    }
}
