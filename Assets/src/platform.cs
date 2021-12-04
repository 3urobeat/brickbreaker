using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float speed;
    
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
}
