using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    private Rigidbody2D PlayerBody;
    public SpriteRenderer Fox, Bear, Bunny;
    public float moveX;
    public float MaxX;
    public float speed;


    private void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        int animalCount = ScoreManager.Instance.AnimalCount;
        moveX = Input.GetAxis("Horizontal");

        if (ScoreManager.Instance.AnimalCount == 1)
        {
            speed = 80;
            MaxX = 20;
        }
        if (ScoreManager.Instance.AnimalCount == 2)
        {
            speed = 80;
            MaxX = 20;
        }
        if (ScoreManager.Instance.AnimalCount == 3)
        {
            speed = 120;
            MaxX = 90;
        }

        if (moveX < 0)
        {
            Bear.flipX = true;
            Fox.flipX = true;
            Bunny.flipX = true;
        }
        else if (moveX > 0)
        {
            Bear.flipX = false;
            Fox.flipX = false;
            Bunny.flipX = false;
        }

        if (PlayerBody.velocity.x <= MaxX && PlayerBody.velocity.x >= -MaxX)
        {
            moveX *= speed;
            PlayerBody.AddForce(new Vector2(moveX, 0));
        }
    }










}
