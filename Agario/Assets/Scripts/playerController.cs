using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int count;

    public float speed;

    private int score;
    public TMP_Text scoreText;
   // public TMP_Text winText;
    public TMP_Text loseText;

    Vector3 color;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        SetScoreText();
        //winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) )
        {
            transform.localScale = new Vector3(transform.localScale.x * 0.95f, transform.localScale.y * 0.95f, 0);
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            transform.localScale = new Vector3(transform.localScale.x * 0.95f, transform.localScale.y * 0.95f, 0);
        }

        if(transform.localScale.magnitude < 0.9f)
        {
            gameObject.SetActive(false);
            loseText.text = "GAME OVER";
        }
        SetScoreText();
    }

   
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if(count >= 15)
        {
            //winText.text = "YOU WIN";
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == ("Enemy"))
        {
            if (transform.localScale.magnitude / 2 > other.transform.localScale.magnitude / 2) //if he's larger than enemy
            {
                transform.localScale = new Vector3(transform.localScale.x * 1.2f, transform.localScale.y * 1.2f, 0);
                if(other.transform.localScale.magnitude / 2 <= 1)
                {
                    score = score + 10;
                }
                else if (other.transform.localScale.magnitude / 2 <= 2 )
                {
                    score = score + 20;
                }
                else if (other.transform.localScale.magnitude / 2 <= 3)
                {
                    score = score + 30;
                }
                else if (other.transform.localScale.magnitude / 2 > 3)
                {
                    score = score + 40;
                }
                count++;
                other.gameObject.SetActive(false);
            }
            else //if you're smaller than the enemy
            {
                gameObject.SetActive(false);
                loseText.text = "GAME OVER";
            }
        }

       
    }
}

