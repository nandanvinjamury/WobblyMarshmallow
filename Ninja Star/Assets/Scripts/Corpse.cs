using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    bool corpseGrounded;
    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public bool IsGrounded()
    {
        return corpseGrounded;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Corpse")
        {
            corpseGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Corpse")
        {
            corpseGrounded = false;
        }
    }
}
