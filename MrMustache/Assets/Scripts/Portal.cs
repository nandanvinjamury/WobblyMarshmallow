using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public Portal otherportal;      //the other portal, not this object
    //public GameObject zoom;
    GameObject mainCharacter;       //main character
    float numberOfMinions;          //num of minions in the level
    bool active,teleporting;         //is the portal active (will it teleport)
    Vector3 colliderCenter;
    private AudioSource audio2;

	// Use this for initialization
	void Start () {
        mainCharacter = GameObject.FindGameObjectWithTag("Player");
        colliderCenter = GetComponent<Collider2D>().bounds.center;
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Portal");
        /*for(int i = 0; i < temp.Length; i++)
        {
            if (temp[i] != this.gameObject)
                otherportal = temp[i].GetComponent<Portal>();
        }*/
        active = false;
        teleporting = false;
        audio2 = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        //if (teleporting)
        //{
           // zoom.transform.Translate(otherportal.transform.position * .001f);
            //if ((zoom.transform.position.x <= otherportal.transform.position.x - .1) || (zoom.transform.position.x >= otherportal.transform.position.x + .1))
//{
             //   teleporting = false;
           //     zoom.transform.position = new Vector3(500, 500, 0);
           // }
        //}
    }

    public bool getActive()
    {
        return active;
    }

    //teleport passed game object to other portal
    void teleport(GameObject minion, float x, float y)
    {
        otherportal.GetComponent<CircleCollider2D>().enabled = false;
       // teleporting = true;
       // zoom.transform.position = transform.position;
        minion.transform.position = new Vector2(otherportal.transform.position.x + x, otherportal.transform.position.y + y);
        audio2.Play();
    }

    public void movePortal()
    {
        
        gameObject.transform.position = mainCharacter.transform.position  - new Vector3(0f, 1f, 0f);
        if (active)
        {
            if (otherportal.getActive())
                otherportal.removePortal();
  

        }
        active = true;

    }

    public void removePortal()
    {
        active = false;
        otherportal.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.transform.position = new Vector3(0f,500f,0f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
            removePortal();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (active && otherportal.getActive())
        {
            //where minion is coming from
            if (Mathf.Abs(colliderCenter.x - collision.gameObject.transform.position.x) > Mathf.Abs(colliderCenter.y - collision.gameObject.transform.position.y))
            {
                //from left or right
                if (transform.position.x <= collision.gameObject.transform.position.x)
                { //from right
                    Debug.Log("from right");
                    teleport(collision.gameObject, 0, 0f);
                }
                else
                {//from left
                    Debug.Log("from left");
                    teleport(collision.gameObject, 0, 0f);
                }
            }
            else
            {//from top or bottom
                if (transform.position.y >= collision.gameObject.transform.position.y)
                {//from top
                    Debug.Log("from up");
                    teleport(collision.gameObject, 0f, 0);
                }
                else
                {//from bottom
                    Debug.Log("from down");
                    teleport(collision.gameObject, 0f, 0);
                }
            }
        }

    }
}
