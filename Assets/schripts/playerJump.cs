using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{
    private Rigidbody2D PlayerBody;
    public float JumpForce;
    public bool grounded = false;
    private Transform PlayerIcon;
    private CircleCollider2D PlayerBox;
    public bool Small = false;
   public GameObject UIE;


    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
        PlayerIcon = GetComponent<Transform>();
        PlayerBox = GetComponent<CircleCollider2D>();
        UIE.SetActive(false);
    }

    void Update()
    {
        int animalCount = ScoreManager.Instance.AnimalCount;
        if (animalCount == 1)
        {
            JumpForce = 40;
        }
        if (animalCount == 2)
        {
            JumpForce = 30;
        }
        if (animalCount == 3)
        {
            UIE.SetActive(true);
            JumpForce = 30;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Small = !Small;
                if (Small == false)
                {
                    PlayerBox.radius *= 2;
                    Debug.Log("smoll");
                    PlayerIcon.localScale = new Vector2(1, 1);
                    UIE.SetActive(false);
                }    
                if (Small == true)
                 {
                PlayerIcon.localScale = new Vector2( 1,0.2f);
                PlayerBox.radius *= 0.5f;
                    
                }
            }


        }
        if (grounded && Input.GetKeyDown(KeyCode.W) || grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 JumpVector = new Vector2(0, JumpForce);
            PlayerBody.velocity = JumpVector;
            grounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

}
