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
    public float height = 1;
    public LayerMask ground;


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
            if (Small == true)
            {
                PlayerBox.radius *= 2;
                PlayerIcon.localScale = new Vector2(1, 1);
                Small = false;
            }
        }
        if (animalCount == 2)
        {
            JumpForce = 30;
            if (Small == true)
            {
                PlayerBox.radius *= 2;
                PlayerIcon.localScale = new Vector2(1, 1);
                Small = false;
            }
            
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
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector3.down, height, ground);
        if (hits.Length > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + height * Vector3.down);
    }
}
