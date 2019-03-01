using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use this class on dangerous objects and finish line object
public class DestroyMinion : MonoBehaviour {

    public AudioSource aud;
    GameObject explosion;

    private void Start()
    {
        explosion = GameObject.FindGameObjectWithTag("Explosion");
    }

    // Update is called once per frame
    void Update () {
        //if (savedMinions + deadMinions == numOfMinions) ;
            //end level
	}

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Minion"))
        {

            if (gameObject.tag.Equals("Dangerous"))
            {
                MinionCount.killMinion();
                Instantiate(explosion, collision.transform.position, transform.rotation);
                aud.Play();
            }
            else if (gameObject.tag.Equals("Finish"))
            {
                MinionCount.saveMinion();
                aud.Play();
            }
            Destroy(collision.gameObject);
        }
    }
}
