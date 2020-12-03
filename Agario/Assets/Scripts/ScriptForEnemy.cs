using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking.Types;

//ethan rennick c00240102

public class ScriptForEnemy : MonoBehaviour
{
    public float randomAcceleration;
    public Vector3 velocity;
    float randomSize;
    int maxSpeed;
    public GameObject enemy;
    float wall;

    // Start is called before the first frame update
    void Start()
    {
        wall = 0.6f;
        randomSize = UnityEngine.Random.Range(0.5f, 4f); //one number
        enemy.transform.localScale = new Vector3(randomSize, randomSize, 0);

         //i think this is the code to define radius. probably change x&y coords to match + make a circle, not an oval
        velocity.Set(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), 0); //random velocity
        randomAcceleration = UnityEngine.Random.Range(-1.1f, 1.1f);

        maxSpeed = 2; //max speed no more than 5        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        velocity.x += randomAcceleration * Time.deltaTime;
        velocity.y += randomAcceleration * Time.deltaTime;
        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        //borders
        if (transform.position.y - wall < -4.5  || transform.position.y + wall > 4.5)
        {
            randomAcceleration = UnityEngine.Random.Range(-1.1f, 1.1f);
             velocity = new Vector3(velocity.x, -velocity.y, 0); //reverse the y
        }

        //left right
        if (transform.position.x - wall < -8.5   || transform.position.x + wall> 8.5)
        {
            randomAcceleration = UnityEngine.Random.Range(-1.1f, 1.1f);
            velocity = new Vector3(-velocity.x, velocity.y, 0); //reverse the x 
        }

        if (transform.localScale.magnitude <= 1)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else if (transform.localScale.magnitude >= 1 && transform.localScale.magnitude <= 2)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (transform.localScale.magnitude >= 2 && transform.localScale.magnitude <= 3)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (transform.localScale.magnitude >= 3 && transform.localScale.magnitude <= 4)
        {
            transform.GetComponent<SpriteRenderer>().color = Color.yellow;
        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == ("Enemy"))
        {
            if (transform.localScale.magnitude / 2 > other.transform.localScale.magnitude / 2) //if he's larger than enemy
            {
                transform.localScale = new Vector3(transform.localScale.x * 1.09f, transform.localScale.y * 1.09f, 0);
                other.gameObject.SetActive(false);
            }
            else //if you're smaller than the enemy
            {
                gameObject.SetActive(false);
                other.transform.localScale = new Vector3(other.transform.localScale.x * 1.09f, other.transform.localScale.y * 1.09f, 0);

            }
        }
    }
}


