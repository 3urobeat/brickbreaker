using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    public float maxBounceAngle;
    public Transform ball;
    
    private Vector3 _direction = new Vector3();
    private Vector2 _field;
    private Ball _ball;
    private Rigidbody2D _ballRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _field = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight));
        transform.position = new Vector3(0, -4.25f, 0); //Set position to start point
        
        _ballRigidbody = ball.GetComponent<Rigidbody2D>();
        _ball = ball.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * speed, -_field.x + transform.localScale.x / 2, _field.x - transform.localScale.x / 2), transform.position.y); //set velocity of rigidBody
    }

    //Handle trajectory change on ball collision (I didn't know how to implement it myself - Credit: https://www.youtube.com/watch?v=RYG8UExRkhA)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the ball hit
        if (collision.collider.transform == ball)
        {
            Vector3 platformPosition = transform.position;                 //Get position of the platform
            Vector2 collisionPoint   = collision.GetContact(0).point; //Get point where the ball hit the platform

            float offset = platformPosition.x - collisionPoint.x;     //calculate distance between position and hit to calculate amount of trajectory change
            float width  = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, _ballRigidbody.velocity);
            float bounceAngle  = (offset / width) * maxBounceAngle;
            float newAngle     = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            _ballRigidbody.velocity = rotation.normalized * Vector2.up * _ballRigidbody.velocity.magnitude;
        }
    }
}
