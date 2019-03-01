using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

    Animator anim;
    PlayerController player;
    Vector3 mousePos;
    Vector3 playerPosition;
    float xmousePosition;
    float ymousePosition;
    float distance;
    float theta;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerPosition = transform.position;
    }

    public void walk()
    {
        playerPosition = transform.position;
        mousePos = player.getMousePosition();
        Debug.Log("mouse: " + mousePos);
        Debug.Log("player: " + playerPosition);
        if(Mathf.Abs(mousePos.x - playerPosition.x) >= Mathf.Abs(mousePos.y - playerPosition.y))
        {
            if(mousePos.x > playerPosition.x)
            {
                anim.SetTrigger("walkRight");
            }
            else
            {
                anim.SetTrigger("walkLeft");
            }
        }
        else
        {
            if(mousePos.y < playerPosition.y)
            {
                anim.SetTrigger("walkDown");
            }
            else
            {
                if (mousePos.x > playerPosition.x)
                {
                    anim.SetTrigger("walkRight");
                }
                else
                {
                    anim.SetTrigger("walkLeft");
                }
            }
        }

    }

    public void idle()
    {
        anim.SetTrigger("idle");
    }
}
