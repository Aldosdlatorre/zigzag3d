using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    public GameObject pickUpEffect;
    public float moveSpeed = 5;
    bool movingLeft = true;
    bool firstInput = true;

    void Start()
    {

    }

    int lastScoreCheckpoint = 0;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            int currentScore = GameManager.instance.GetScore(); // línea nueva
            if (currentScore >= lastScoreCheckpoint + 20)
            {
                lastScoreCheckpoint = currentScore;
                moveSpeed += 1f; // o la cantidad que desees aumentar
            }
            Move();
            CheckInput();
        }

        if (transform.position.y <= -3)
        {
            GameManager.instance.GameOver();
        }

    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void CheckInput()
    {

        // If first input then ignore
        if (firstInput)
        {
            firstInput = false;
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Coin")
        {
            GameManager.instance.IncrementScore();
            Instantiate(pickUpEffect, other.transform.position, pickUpEffect.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
