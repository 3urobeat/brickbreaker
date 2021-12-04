using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4f, 0); //Set position to start point

        Vector2 force = new Vector2(0, 0);
        force.x = Random.Range(-1f, 1f);       //get a random number between -1 and 1 to randomize trajectory on start a bit
        force.y = -1f;
        
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(force.normalized * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
