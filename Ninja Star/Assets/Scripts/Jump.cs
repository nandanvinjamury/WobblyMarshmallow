using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    private bool isGrounded;
    public float jumpForce = 600f;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
            if ((Input.GetButton("Jump") && isGrounded))
            {
                SoundManagerScript.PlaySound("jump");
				rb.AddRelativeForce (new Vector3(0, jumpForce,0));
				isGrounded = false;
            }
    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Corpse")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            SoundManagerScript.PlaySound("jumpland");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Corpse")
        {
            isGrounded = false;
        }
    }
}
