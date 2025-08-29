using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W) && transform.position.y < 4.0f)
        {
            direction = Vector2.up * speed;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -4.0f)
        {
            direction = Vector2.down * speed;
        }
        rigidbody.velocity = direction * speed;
    }
}
