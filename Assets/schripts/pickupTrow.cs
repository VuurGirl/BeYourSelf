using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pickupTrow : MonoBehaviour
{
    public Rigidbody2D LogBody;
    public bool pickUp=false;
    public bool Inform = false;
    public Transform bear;
    public int power;
    public GameObject UIE;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inform = true;
            UIE.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inform = false;
            UIE.SetActive(false);
        }
    }

    void Update()
    {
        int animalCount = ScoreManager.Instance.AnimalCount;
        if (pickUp == true)
        {
            transform.position = bear.position + new Vector3(1, 0, 0);
        }

        if (animalCount == 2 &&  (Inform || pickUp) && Input.GetKeyDown(KeyCode.E))
        {
            pickUp =! pickUp;
            Debug.Log("picked up");
            if (pickUp == false){
                LogBody.velocity = Vector2.zero;
                LogBody.AddForce(new Vector2(power, power));
                }
            
        }
        if (animalCount != 2)
        {
            pickUp = false;
            LogBody.constraints = RigidbodyConstraints2D.FreezeAll;

        }
        else 
        { LogBody.constraints = RigidbodyConstraints2D.FreezeRotation; }
    }
}

