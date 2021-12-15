using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed;
    public float maxBounceAngle;
    public float velocity;

    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4f, 0); //Set position to start point

        Vector2 direction = new Vector2(Random.Range(-1f, 1f), -1f); //get a random number between -1 and 1 to randomize trajectory on start a bit

        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        velocity = _rigidbody.velocity.magnitude;
    }
}
