using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public Transform gameController;
    public float speed;
    public float maxBounceAngle;
    public float velocity;
    public GameObject scoreCounter;
    public GameObject resultPanel;

    public int hits;
    
    private Rigidbody2D _rigidbody;
    private BrickGen _brickGen;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4f, 0); //Set position to start point

        Vector2 direction = new Vector2(Random.Range(-1f, 1f), -1f); //get a random number between -1 and 1 to randomize trajectory on start a bit

        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.velocity = direction.normalized * speed;
        
        _brickGen = gameController.GetComponent<BrickGen>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        velocity = _rigidbody.velocity.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Brick")
        {
            Destroy(col.gameObject); //Destroy brick on hit

            hits++;
            scoreCounter.GetComponent<Text>().text = "Score: " + hits;

            //Show win screen if player hit all bricks
            if (hits >= _brickGen.rows * _brickGen.cols)
            {
                resultPanel.SetActive(true);
                resultPanel.GetComponentInChildren<Text>().text = "Win!";
                
                scoreCounter.SetActive(false); //hide the ingame score counter
        
                Destroy(gameObject); //stop the ball from floating around in the empty void of its existence
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Only the bottom wall has a trigger for checking for a failure
        resultPanel.SetActive(true);
        resultPanel.GetComponentInChildren<Text>().text = "Failure\n\nYour Score: " + hits;
        
        scoreCounter.SetActive(false); //hide the ingame score counter
        
        Destroy(gameObject); //stop the ball from floating around in the empty void of its existence
    }
}
