using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : MonoBehaviour {

    Rigidbody2D rb2d;
    Vector2 direction;
    float speed;
 

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = new Vector2(0, -1);
        speed = 1;
    }

    // Update is called once per frame
    void Update () {

        rb2d.AddForce(direction*speed);
        if (Input.GetKeyDown(KeyCode.E))
        {
            speed = 4;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            speed = 1;
        }
    }

    public Vector2 getDirection()
    {
        return direction;
    }

    public void setDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Minion")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
