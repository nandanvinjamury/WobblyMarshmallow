using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    private float scalar = 1.0f;
    public GameObject Player;
    private float timeOut = 5.0f,timer;
    private Rigidbody2D rb;

    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeOut)
        {
            Destroy(this.gameObject);
        }
    }

	public void Teleport (Vector2 vel,GameObject Shooter)
    {
        /*Fun stuff to mess around with, don't actually uncomment!
        if (vel.y < 0)
        {
            vel.y = -vel.y + (vel.y/2);
        } else if (vel.y > 15)
        {
            vel.y = vel.y - (vel.y / 2);
        }
        if (vel.x > 15)
        {
            vel.x = vel.x - (vel.x / 2);
        }else if (vel.x < -15)
        {
            vel.x = -vel.x + (vel.x / 2);
        }*/
        GameObject newplayer = Instantiate(Player,this.gameObject.transform.position,Player.transform.rotation);
        newplayer.GetComponentInChildren<Rigidbody2D>().velocity = vel * scalar;
		soul.target = newplayer;
		soul.Showspirit = true;
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Corpse")
        {
            Destroy(this.gameObject);
        }
    }
}
