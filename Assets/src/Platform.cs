using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    public float maxBounceAngle;
    
    private Rigidbody2D _rigidBody;
    private Vector2 _direction;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4.25f, 0); //Set position to start point
        
        _rigidBody = gameObject.GetComponent<Rigidbody2D>(); //assign rigidBody on start
    }

    // Update is called once per frame
    void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), 0); //Direction of the input
        
        _rigidBody.velocity = speed * _direction; //set velocity of rigidBody
    }

    //Handle trajectory change on ball collision (I didn't know how to implement it myself - Credit: https://www.youtube.com/watch?v=RYG8UExRkhA)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        //Check if the ball hit
        if (ball)
        {
            Vector3 platformPosition = transform.position;                 //Get position of the platform
            Vector2 collisionPoint   = collision.GetContact(0).point; //Get point where the ball hit the platform

            float offset = platformPosition.x - collisionPoint.x;     //calculate distance between position and hit to calculate amount of trajectory change
            float width  = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().velocity);
            float bounceAngle  = (offset / width) * maxBounceAngle;
            float newAngle     = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.GetComponent<Rigidbody2D>().velocity =
                rotation * Vector2.up * ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
    }
}
