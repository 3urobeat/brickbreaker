using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D _rigidBody;
    private Vector2 _direction;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>(); //assign rigidBody on start
    }

    // Update is called once per frame
    void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), 0); //Direction of the input
        
        _rigidBody.velocity = speed * _direction; //set velocity of rigidBody
    }
}
