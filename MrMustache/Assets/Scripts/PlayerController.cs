using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private AudioSource audio;
    private GameObject myCam; //creates a gameobject that will be the camera
    private Transform playerTransform; //main character's transform
    private Vector3 mousePos; //will find mouse position
    public float speed; //speed of the player
    bool mouseSet; //checks if mouse position has been set
    public Portal portal;
    public Portal portal2;
    private PlayerAnim anim;
    public static bool portalset;
    public static bool portal2set;

	void Start () {
        //myCam = GameObject.Find("Main Camera"); //finds the main camera; not necessary right now, maybe later
        playerTransform = gameObject.transform; //sets transform to player transform
        mouseSet = false;
        portalset = false;
        portal2set = false;
        anim = GetComponent<PlayerAnim>();
        audio = GetComponent<AudioSource>();
	}


    void Update() {
        MouseMovement();
        PortalPlacement();
	}

    void MouseMovement()
    {
        speed = speed * Time.deltaTime; //fixes the speed so it looks natural based on time
        Vector3 depth = new Vector3(1, 1, 0); //a multiplier which makes sure that the player does not switch depths when clicking

        if (Input.GetMouseButtonDown(1))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //updates position of the mouse on click
            mouseSet = true; //the click signifies that the position to transform to has been set
        }

        if (mouseSet)
        {
            anim.walk();
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, Vector3.Scale(mousePos+new Vector3(0,0.8f,0), depth), 5 * Time.deltaTime); //moves towards mouse
        }
        if (Mathf.Abs(playerTransform.position.x - mousePos.x) < .1f && Mathf.Abs(playerTransform.position.y - mousePos.y-0.8f) < .1f) //if the player is where the click happened
        {
            anim.idle();
            mouseSet = false; //the mouse has not been set to move again
        }
        
    }

    public Vector3 getMousePosition()
    {
        return mousePos;
    }

    void PortalPlacement()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            audio.Play();
            portal.movePortal();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            audio.Play();
            portal2.movePortal();
        }
       

    }
}
