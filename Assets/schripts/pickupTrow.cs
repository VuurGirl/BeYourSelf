using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pickupTrow : MonoBehaviour
{

    private Rigidbody2D LogBody;
    public bool pickUp = false;
    public bool Inform = false;
    public Transform bear;
    public int power;
    public GameObject UIE;
    public bool switcheroe;

    private void Awake()
    {
        LogBody = GetComponent<Rigidbody2D>();
    }


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

        float moveX = Input.GetAxis("Horizontal");
        if (pickUp == true)
        {
            if (switcheroe == false)
            {
                transform.position = bear.position + new Vector3(1, 0, 0);
            }
            if (switcheroe == true)
            {
                transform.position = bear.position + new Vector3(-1, 0, 0);
            }
            if (moveX < 0)
            {
                switcheroe = true;
            }
            if (moveX > 0)
            {
                switcheroe = false;
            }
        }
     
        if (ScoreManager.Instance.AnimalCount != 2)
        {
            pickUp = false;
            LogBody.velocity = Vector2.zero;
            LogBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (ScoreManager.Instance.AnimalCount == 2)
        { 
            LogBody.constraints = RigidbodyConstraints2D.FreezeRotation; 
        }

        if (ScoreManager.Instance.AnimalCount == 2 && (Inform || pickUp) && Input.GetKeyDown(KeyCode.E))
        {
            pickUp = !pickUp;
            if (pickUp == false && switcheroe == false)
            {
                LogBody.velocity = Vector2.zero;
                LogBody.AddForce(new Vector2(power, power));
            }
            if (pickUp == false && switcheroe == true)
            {
                LogBody.velocity = Vector2.zero;
                LogBody.AddForce(new Vector2(-power, power));
            }
        }
    }
}

